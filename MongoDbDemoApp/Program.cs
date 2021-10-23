using MongoDbDemoApp.Models;
using System;

namespace MongoDbDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoCRUD db = new MongoCRUD("AddressBook");

            //Post Operation

            //db.InsertRecord<Person>("Users", new Person { FirstName = "Ahmet", LastName = "M" });
            //db.InsertRecord<Person>("Users", new Person { FirstName = "Gözde", LastName = "M" });

            //Person person = new Person()
            //{
            //    FirstName = "Seckin",
            //    LastName = "M",
            //    PrimaryAddress = new Address()
            //    {
            //        StreetAddress = "101 Mile Oak",
            //        City = "Brighton",
            //        State = "Sussex",
            //        ZipCode = "Bn1 1Ul"
            //    }
            //};
            //db.InsertRecord<Person>("Users", person);

            //***************************************************************
            //Get Operation

            var recs = db.LoadRecords<Person>("Users");

            foreach (var rec in recs)
            {
                Console.Write($"Person Id = {rec.Id} : Person Name = {rec.FirstName}, Person LastName = {rec.LastName}");
                if (rec.PrimaryAddress != null)
                {
                    Console.WriteLine($" Person's City = {rec.PrimaryAddress.City}");
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
