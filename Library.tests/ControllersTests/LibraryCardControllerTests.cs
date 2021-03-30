using Library.ConrtrollerTests.RepositoryTest;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using Xunit;

namespace Library.tests.ControllersTests
{
    public class LibraryCardControllerTests
    {

        static DataInsertTest _context = new DataInsertTest();
        static LibraryCardsRepository _bookRepository = new LibraryCardsRepository(_context);
        static LibraryCardController _bookConrtroller = new LibraryCardController(_bookRepository);
        [Fact]
        public static void UpdateLibreryCard_NotEmpty()
        {
            int bookID = 1;
            int userID = 1;
            int dats = 7;
            
            var rezult = _bookConrtroller.ChangeRefund(bookID, userID, dats);
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void DatesRefund_NotEmpty()
        {
            
            var rezult = _bookConrtroller.AllRefund();
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void CheakRefundPerson_NotEmpty()
        {
            int personID = 1;
            
            var rezult = _bookConrtroller.AllRefund();
            Assert.NotEmpty(rezult);
        }

    }
}
