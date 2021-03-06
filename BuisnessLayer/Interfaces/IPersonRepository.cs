using System;

namespace BuisnessLayer.Interfaces
{
    public interface IPersonRepository
    {

        public string NewPerson(DateTime BirthDay, String FirstName, String MiddleName, String LastName);
        public string ChangePerson(string firstName, string middleName, string lastName, int personID, DateTime BirthDay);
        public bool DeletePerson(int personID);
        public bool DeletePerson(string name, string middleName, string lastName);
        public string NewLibraryCard(int personID, int bookID);
        public string DeleteLibraryCard(int bookID, int personID);
        public void Save();
        public string AllbooksPerson(int personID);
        
    }
}

