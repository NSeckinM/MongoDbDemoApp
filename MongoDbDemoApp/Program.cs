using MongoDbDemoApp.Models;
using System;

namespace MongoDbDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoCRUD db = new MongoCRUD("AddressBook");

            db.InsertRecord<Person>("Users", new Person { FirstName = "Ahmet", LastName = "M" });
            db.InsertRecord<Person>("Users", new Person { FirstName = "Gözde", LastName = "M" });
            

            Console.ReadLine();

        }
    }
}
