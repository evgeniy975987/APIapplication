using Library.Insert.Data;
using System;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using WebApplication2.Entitys;
using Xunit;

namespace Library.tests.ControllersTests
{
    public class PersonControllerTests
    {
        static DataInsertTest _context = new DataInsertTest();
        static PersonRepository _authorRepository = new PersonRepository(_context);
        static PersonController _authorsController = new PersonController(_authorRepository);
        [Fact]
        public static void NewPerson_NotNull()
        {
            Person person = new Person();
            person.BirthDay = DateTime.Now;
            person.FirstName = "first name";
            person.MiddleName = "middle Name";
            person.LastName = "middle Name";
            var rezult = _authorsController.NewPerson(person);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void ChangePerson_NotNull()
        {
            Person person = new Person();
            person.BirthDay = DateTime.Now;
            person.FirstName = "first name";
            person.MiddleName = "middle Name";
            person.LastName = "middle Name";
            person.PersonID = 10;
            var rezult = _authorsController.ChangePerson(person);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void DeletePerson_NotNull()
        {
            int ID = 7;
            var rezult = _authorsController.DeletePerson(ID);
            Assert.True(rezult);
        }
        [Fact]
        public static void DeletePerson_True()
        {
            string firstName = "first_name4";
            string midleName = "middle_Name4";
            string lastName = "last_Name4";
            
            var rezult = _authorsController.DeletePerson(firstName, midleName, lastName);
            Assert.True(rezult);
        }
        [Fact]
        public static void NewLibraryCards_NotNull()
        {
            int personID = 20;
            int bookID = 20;
            var rezult = _authorsController.NewLibraryCards(bookID, personID);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void DeleteLibraryCard_NotNull()
        {
            int personID = 20;
            int bookID = 20;
            var rezult = _authorsController.DeleteLibraryCard(bookID, personID);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void AllBooksPerson_NotEmpty()
        {
            int personID = 1;
            var rezult = _authorsController.AllBooksPerson(personID);
            Assert.NotEmpty(rezult);
        }

    }
}
