using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using Workers;
using Xunit;

namespace Library.tests
{
    public class LibraryCardControllerTest
    {

        static Mock<LibraryCardsRepository> Test = new Mock<LibraryCardsRepository>(new ApplicationContext());
        static LibraryCardController libraryCardController = new LibraryCardController(Test.Object);

        [Fact]
        public static void UpdateLibreryCard_NotEmpty()
        {
            var rezult = libraryCardController.UpdateLibreryCard(2, 1, 11);
            Assert.NotEmpty(rezult);
        }


        [Fact]
        public static void DatesRefund_NotEmpty()
        {
            var rezult = libraryCardController.DatesRefund();
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void CheakRefundPerson_NotEmpty()
        {
            var rezult = libraryCardController.CheakRefundPerson(1);
            Assert.NotEmpty(rezult);
        }
    }
}
