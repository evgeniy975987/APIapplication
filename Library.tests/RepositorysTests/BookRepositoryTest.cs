using System;
using Xunit;
using WebApplication2.Models;
using WebApplication2.data.reposytorys;
using Moq;
using WebApplication2.Controllers;
using System.Collections.Generic;
using Workers;
using BuisnessLayer;
using BuisnessLayer.Interfaces;
using Library.ConrtrollerTests.RepositoryTest;

namespace Library.ConrtrollerTests
{
    
    public class BookRepositoryTest
    {

        static DataInsertTest _context = new DataInsertTest();
        static Mock<IBookRepository> _mock = new Mock<IBookRepository>();

        static BookRepository bookRepository = new BookRepository(_context);

        [Fact]
        public static void AllBooksAuthor_4_NotEmpty()
        {
            int authorID = 2;

            _mock.Setup(p => p.AllBooksAuthor(authorID)).Returns(bookRepository.AllBooksAuthor(authorID));
            var rezult = _mock.Object.AllBooksAuthor(authorID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void AllBooksGenre_2_NotEmpty()
        {
            int genreID = 2;
            var rezult = bookRepository.AllBooksGenre(genreID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void DeleteBook_4_NotNull()
        { 
            int bookID = 10;

            _mock.Setup(p => p.DeleteBook(bookID)).Returns(bookRepository.DeleteBook(bookID));
            var rezult = _mock.Object.AllBooksAuthor(bookID);
            
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void NewBook()
        {
            Author author = new Author();
            author.first_name = "Тест";
            author.middle_name = "middle name";
            author.last_name = "Last Name";
            Book book = new Book();
            book.Title = "test";
            Genre genre = new Genre();
            genre.name = "Test";


            _mock.Setup(p => p.NewBook(book, author, genre)).Returns(bookRepository.NewBook(book, author, genre));
            var rezult = _mock.Object.NewBook(book, author, genre);

            
            Assert.Equal("Добавлен", rezult);
        }

        [Fact]
        public static void UpdateBookGenre_4_4_true_NotNull()
        {
            int genreID = 10;
            int bookID = 10;
            bool choise = true;

            _mock.Setup(p => p.UpdateBookGenre(genreID, bookID, choise)).Returns(bookRepository.UpdateBookGenre(genreID, bookID, choise));
            var rezult = _mock.Object.UpdateBookGenre(genreID, bookID, choise);

            
            Assert.NotNull(rezult);
        }
        
    }
    
}
