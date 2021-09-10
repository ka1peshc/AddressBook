using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static public string Firstname, Lastname, Address, City, State, Email;
        static public int zipNo;
        static public long Phonenumber;
        
        private void takeInput()
        {
            Console.WriteLine("Enter values according Firstname, Lastname, Address, City, State, Email");
            Console.WriteLine("Zip Number, Phone number");
            Firstname = Console.ReadLine();
            Lastname = Console.ReadLine();
            Address = Console.ReadLine();
            City = Console.ReadLine();
            State = Console.ReadLine();
            Email = Console.ReadLine();
            zipNo = int.Parse(Console.ReadLine());
            Phonenumber = long.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            //declare dictionary
            IDictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
            Program p = new Program();
            for(int i = 1; i < 3; i++)
            {
                
                string temp = DateTime.Now.ToString("yyyy-MM-dd");  
                p.takeInput();
                Contact contact = new Contact(Firstname, Lastname, Address, City, State, Email, Phonenumber, zipNo);
                temp = Firstname + temp;
                addressBook.Add(temp, contact);
            }
            //Contact contact = new Contact("Kalpesh", "Chindarkar", "Sewri west", "Mumbai", "Maharashtra", "kalpesh111997@gmail.com", 9920036999, 400015);
            foreach(KeyValuePair<string,Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine("Name :{0} {1}", kvp.Value.firstname, kvp.Value.lastname);
                Console.WriteLine("Address :{0},{1},{2},{3}",kvp.Value.address,kvp.Value.City,kvp.Value.zipNo,kvp.Value.State);
                Console.WriteLine("Phone number: {0}", kvp.Value.Phonenumber);
                Console.WriteLine();
            }

        }
    }
}
