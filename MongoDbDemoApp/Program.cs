using System;

namespace MongoDbDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoCRUD db = new MongoCRUD("AddressBook");
            Console.ReadLine();

        }
    }
}
