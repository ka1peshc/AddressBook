using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static IDictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            
            CRUDoperationOnContact crudContact = new CRUDoperationOnContact();
                        
            bool xyz = true;
            while (xyz)
            {
                Console.WriteLine("select option");
                Console.WriteLine("1. Add new contact \n2. Update contact \n3. Delete contact" +
                    "\n4. Display All Record\n5. Display person based on state or City" +
                    "\n6. Display person name and city\n7. Display person name and state" +
                    "\n8. Read File using StreamReader\n9. Exit program");
                int option = int.Parse(Console.ReadLine());
                switch (option) {
                    case 1:
                        crudContact.takeInput(addressBook);
                        break;
                    case 2:
                        crudContact.updateRecord(addressBook);
                        break;
                    case 3:
                        crudContact.deleteRecord(addressBook);
                        break;
                    case 4:
                        crudContact.displayAddressBook(addressBook);
                        break;
                    case 5:
                        crudContact.DisplayPersonName(addressBook);
                        break;
                    case 6:
                        crudContact.DisplayPersonAndCity();
                        break;
                    case 7:
                        crudContact.DisplayPersonAndState();
                        break;
                    case 8:
                        crudContact.ReadFileUsingStreamReader();
                        break;
                    case 9:
                        return;
                    default:
                        xyz = false;
                        break;
                }
            }

        }
    }
}
