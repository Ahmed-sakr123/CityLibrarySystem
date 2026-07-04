using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace LibrarySystem.Entities
{
    public class Librarian : LibraryUser

    {
        private static int _librarianCount = 0;
        private decimal salary;

        public string ID { get; private set; }
        public string Salary { get; private set; }
        public DateOnly HireDate { get; private set; }

        public Librarian(string id,
                         string salary,
                         DateOnly hireDate,
                         string name,
                         string phoneNumber)
            : base(name, phoneNumber)
        {

            ID = $"LIB-{_librarianCount++:D2}";
            Salary = salary;
            HireDate = hireDate;
           
        }



        public override string DisplayInformations() =>
          $"""
          ID : {ID}
          Name : {Name}
          Salary : {Salary}
          Hire Date : {HireDate:dd/MM/yyyy}

          """;

    }
}

