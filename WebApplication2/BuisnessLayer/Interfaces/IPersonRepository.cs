using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Interfaces
{
    public interface IPersonRepository
    {

        public string NewPerson(DateTime BirthDay, String FirstName, String MiddleName, String LastName);

        public string ChangePerson(string firstName, string middleName, string lastName, int personID, DateTime BirthDay);

        public bool deletePerson(int personID);

        public bool deletePerson(string name, string middleName, string lastName);

        public string NewLibraryCard(int personID, int bookID);

        public string DeleteLibraryCard(int bookID, int personID);

        public void Save();


        public IEnumerable<string> AllbooksPerson(int personID);
        
    }
}

