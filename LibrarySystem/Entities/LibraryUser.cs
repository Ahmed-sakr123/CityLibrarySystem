using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Entities
{
    public abstract class LibraryUser:IDisplayable
    {
        public string Name { get; protected set; } = null;
        public string PhoneNumber { get; protected set; } = null;
        public LibraryUser(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public abstract string DisplayInformations();
    }
}

    
