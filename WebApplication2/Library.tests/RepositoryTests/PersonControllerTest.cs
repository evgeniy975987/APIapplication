using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using WebApplication2.Models;
using Workers;
using Xunit;

namespace Library.tests
{
    public class PersonControllerTest
    {

        static Mock<ApplicationContext> Test2 = new Mock<ApplicationContext>();
        static Mock<PersonRepository> Test = new Mock<PersonRepository>(Test2.Object);
        static PersonController libraryCardController = new PersonController(Test.Object);

        
        
        
        [Fact]
        public static void NewPerson_NotNull()
        {
            

            DateTime date = DateTime.Now;
            string firstName = "first name";
            string midleName = "middle Name";
            string lastName = "middle Name";
           

            var rezult = libraryCardController.NewPerson(date, firstName, midleName, lastName);
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

            var rezult = libraryCardController.UpdatePerson(firstName, midleName, lastName, date, personID);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void DeletePerson_NotNull()
        {
            int ID = 7;

            var rezult = libraryCardController.DeletePerson(ID);
            Assert.True(rezult);
        }
        
        
        [Fact]
        public static void DeletePerson_True()
        {
            string firstName = "first_name4";
            string midleName = "middle_Name4";
            string lastName = "last_Name4";
            var rezult = libraryCardController.DeletePerson(firstName, midleName, lastName);
            Assert.True(rezult);
        }


        [Fact]
        public static void NewLibraryCards_NotNull()
        {
            int personID = 20;
            int bookID = 20;
            var rezult = libraryCardController.NewLibraryCards(bookID, personID);
            Assert.NotNull(rezult);
        }


        [Fact]
        public static void DeleteLibraryCard_NotNull()
        {
            int personID = 20;
            int bookID = 20;
            var rezult = libraryCardController.DeleteLibraryCard(bookID, personID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void AllBooksPerson_NotEmpty()
        {
            int personID = 1;
            var rezult = libraryCardController.AllBooksPerson(personID);
            Assert.NotEmpty(rezult);
        }
    }
}
