using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class CRUDoperationOnContact
    {
        private readonly NLogger nlog = new NLogger();
        internal void takeInput(IDictionary<string, Contact> addressBook)
        {

            string Firstname, Lastname, Address, City, State, Email;
            int zipNo;
            long Phonenumber;

            Console.WriteLine("Enter values according Firstname, Lastname, Address, City, State, Email");
            Firstname = Console.ReadLine();
            Lastname = Console.ReadLine();
            Address = Console.ReadLine();
            City = Console.ReadLine();
            State = Console.ReadLine();
            Email = Console.ReadLine();
            Console.WriteLine("Zip Number, Phone number");
            zipNo = int.Parse(Console.ReadLine());
            Phonenumber = long.Parse(Console.ReadLine());
            Contact contact = new Contact();
            contact.Firstname = Firstname;
            contact.Lastname = Lastname;
            contact.Address = Address;
            contact.City = City;
            contact.State = State;
            contact.Email = Email;
            contact.Zipno = zipNo;
            contact.PhoneNo = Phonenumber;
            string temp = DateTime.Now.ToString("yyyy-MM-dd");
            temp = Firstname + temp;
            
            var tempAddressBook = addressBook;
            bool result = true;
            //Checking for duplicate person 
            foreach ( KeyValuePair<string, Contact> kvp in tempAddressBook)
            {
                if (kvp.Value.Firstname == contact.Firstname && kvp.Value.Lastname == contact.Lastname)
                {
                    Console.WriteLine("Person {0} {1} is alread present in address book record", contact.Firstname, contact.Lastname);
                    nlog.LogError("trying to add duplicate name record");
                    result= false;
                }
            }
            if(result)
            {
                addressBook.Add(temp, contact);
                nlog.LogInfo("Added new Person Record");
            }
        }
        internal void displayAddressBook(IDictionary<string, Contact> addressBook)
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine("Name :{0} {1}", kvp.Value.Firstname, kvp.Value.Lastname);
                Console.WriteLine("Address :{0},{1},{2},{3}", kvp.Value.Address, kvp.Value.City, kvp.Value.Zipno, kvp.Value.State);
                Console.WriteLine("Phone number: {0}", kvp.Value.PhoneNo);
                Console.WriteLine();
                nlog.LogInfo("Called Display method");
            }
        }
        internal void updateRecord(IDictionary<string, Contact> addressBook)
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key+"\t"+kvp.Value.Firstname);
            }
            Console.WriteLine("Type key");
            string key = Console.ReadLine();
            Console.WriteLine("Type name currently seen");
            string currentName = Console.ReadLine();
            Console.WriteLine("Type name you want");
            string editToName = Console.ReadLine();
            CRUDoperationOnContact crud = new CRUDoperationOnContact();
            if (crud.editNameInAddressBook(key, currentName, editToName, addressBook))
            {
                Console.WriteLine("Successfully name updated");
                string msg = "Successfully name updated from " + currentName + " to" + editToName;
                nlog.LogInfo(msg);
                crud.displayAddressBook(addressBook);
            }
        }
        internal void deleteRecord(IDictionary<string, Contact> addressBook)
        {
            Console.WriteLine("Enter key you want to delete");
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key + "  " + kvp.Value.Firstname);
            }
            Console.WriteLine("Enter key and first name");
            string keyName, firstname;
            keyName = Console.ReadLine();
            firstname = Console.ReadLine();
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                if (kvp.Key.Equals(keyName))
                {
                    if (kvp.Value.Firstname.Equals(firstname))
                    {
                        addressBook.Remove(kvp.Key);
                        string msg = "Successfully name updated from " + kvp.Key.ToString();
                        nlog.LogInfo(msg);
                    }
                }
            }
        }
        internal bool editNameInAddressBook(string key, string currentName, string editToName, IDictionary<string, Contact> addressBook)
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                if (kvp.Key.Equals(key))
                {
                    if (kvp.Value.Firstname.Equals(currentName))
                    {
                        kvp.Value.Firstname = editToName;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Check displayed name spelling");
                    }
                }
                else
                {
                    Console.WriteLine("Error 404: Key not found! check key name.");
                }
            }
            return false;
        }
    }
}
