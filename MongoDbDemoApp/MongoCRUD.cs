using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDemoApp
{
    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string databaseName)
        {
            var client = new MongoClient();
            db = client.GetDatabase(databaseName);
        }


        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid id)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        //id si verlien nesne db de varsa update eder yoksa yeni oluşturur.
        public void UpSertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
                                            // filter                 eklenecek    option for isupsert
                                            //db de bakılacak colon      obje
            var result = collection.ReplaceOne(new BsonDocument("_id",id),record,new UpdateOptions { IsUpsert = true});

        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);


        }

    }
}
