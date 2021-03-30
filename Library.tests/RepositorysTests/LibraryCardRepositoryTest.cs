using BuisnessLayer;
using BuisnessLayer.Interfaces;
using Library.ConrtrollerTests.RepositoryTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using Workers;
using Xunit;

namespace Library.ConrtrollerTests
{
    public class LibraryCardRepositoryTest
    {
        static DataInsertTest _context = new DataInsertTest();
        static Mock<ILibraryCardsRepository> _mock = new Mock<ILibraryCardsRepository>();
        static LibraryCardsRepository _libraryCardsRepository = new LibraryCardsRepository(_context);
        [Fact]
        public static void UpdateLibreryCard_NotEmpty()
        {
            int bookID = 1;
            int userID = 1;
            int dats = 7;
            _mock.Setup(p => p.ChangeRefund(bookID, userID, dats)).Returns(_libraryCardsRepository.ChangeRefund(bookID, userID, dats));
            var rezult = _mock.Object.ChangeRefund(bookID, userID, dats);
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void DatesRefund_NotEmpty()
        {
            _mock.Setup(p => p.AllRefund()).Returns(_libraryCardsRepository.AllRefund());
            var rezult = _mock.Object.AllRefund();
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void CheakRefundPerson_NotEmpty()
        {
            int personID = 1;
            _mock.Setup(p => p.AllRefundPerson(personID)).Returns(_libraryCardsRepository.AllRefundPerson(personID));
            var rezult = _mock.Object.AllRefund();
            Assert.NotEmpty(rezult);
        }
    }
}
