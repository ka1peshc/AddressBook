using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contact
    {
        public string firstname, lastname, address, City, State, Email;
        public int  zipNo;
        public long Phonenumber;
        public Contact(string fn, string ln, string addr, string city, string state, string email, long PhNo, int zip)
        {
            firstname = fn;
            lastname = ln;
            address = addr;
            City = city;
            State = state;
            Email = email;
            Phonenumber = PhNo;
            zipNo = zip;
        }

    }
}
