using BuisnessLayer;
using BuisnessLayer.Interfaces;
using Library.ConrtrollerTests.RepositoryTest;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using WebApplication2.Models;
using Workers;
using Xunit;

namespace Library.ConrtrollerTests
{
    public class PersonRepositoryTest
    {

        static DataInsertTest _context = new DataInsertTest();
        static Mock<IPersonRepository> _mock = new Mock<IPersonRepository>();
        static PersonRepository _personRepository = new PersonRepository(_context);
        [Fact]
        public static void NewPerson_NotNull()
        {
            DateTime date = DateTime.Now;
            string firstName = "first name";
            string midleName = "middle Name";
            string lastName = "middle Name";
            _mock.Setup(p => p.NewPerson(date, firstName, midleName, lastName)).Returns(_personRepository.NewPerson(date, firstName, midleName, lastName));
            var rezult = _mock.Object.NewPerson(date, firstName, midleName, lastName);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void UpdateLibreryCard_NotNull()
        {
            DateTime date = DateTime.Now;
            string firstName = "first name2";
            string midleName = "middle Name2";
            string lastName = "last Name2";
            int personID = 10;
            _mock.Setup(p => p.ChangePerson(firstName, midleName, lastName, personID, date)).Returns(_personRepository.ChangePerson(firstName, midleName, lastName, personID, date));
            var rezult = _mock.Object.ChangePerson(firstName, midleName, lastName, personID, date);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void DeletePerson_NotNull()
        {
            int ID = 7;
            _mock.Setup(p => p.DeletePerson(ID)).Returns(_personRepository.DeletePerson(ID));
            var rezult = _mock.Object.DeletePerson(ID);
            Assert.True(rezult);
        }
        
        
        [Fact]
        public static void DeletePerson_True()
        {
            string firstName = "first_name4";
            string midleName = "middle_Name4";
            string lastName = "last_Name4";
            _mock.Setup(p => p.DeletePerson(firstName, midleName, lastName)).Returns(_personRepository.DeletePerson(firstName, midleName, lastName));
            var rezult = _mock.Object.DeletePerson(firstName, midleName, lastName);
            Assert.True(rezult);
        }


        [Fact]
        public static void NewLibraryCards_NotNull()
        {
            int personID = 20;
            int bookID = 20;
            _mock.Setup(p => p.NewLibraryCard(bookID, personID)).Returns(_personRepository.NewLibraryCard(bookID, personID));
            var rezult = _mock.Object.NewLibraryCard(bookID, personID);
            Assert.NotNull(rezult);
        }


        [Fact]
        public static void DeleteLibraryCard_NotNull()
        {
            int personID = 20;
            int bookID = 20;
            _mock.Setup(p => p.DeleteLibraryCard(bookID, personID)).Returns(_personRepository.DeleteLibraryCard(bookID, personID));
            var rezult = _mock.Object.DeleteLibraryCard(bookID, personID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void AllBooksPerson_NotEmpty()
        {
            int personID = 1;
            _mock.Setup(p => p.AllbooksPerson(personID)).Returns(_personRepository.AllbooksPerson(personID));
            var rezult = _mock.Object.AllbooksPerson(personID);
            Assert.NotEmpty(rezult);
        }
        
    }
}
