using System;
using Xunit;
using WebApplication2.Models;
using WebApplication2.data.reposytorys;
using Moq;
using WebApplication2.Controllers;
using System.Collections.Generic;
using Workers;

namespace Library.tests
{
    
    public class BookRepositoryTest
    {
        static Mock<BookRepository> Test = new Mock<BookRepository>(new ApplicationContext());
        static BookController bookController = new BookController(Test.Object);

        [Fact]
        public static void AllBooksAuthor_4_NotEmpty()
        {
            Test.Setup(p => p.AllBooksAuthor(2)).Returns(bookController.AllBookAuthor(2));
            var rezult = bookController.AllBookAuthor(2);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void AllBooksGenre_2_NotEmpty()
        {
            int genreID = 2;
            var rezult = bookController.GetAllBooks(genreID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void DeleteBook_4_NotNull()
        { 
            int bookID = 10;
            string rezult = bookController.DeleteBook(bookID);
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
            var rezult = bookController.NewBook(book, author, genre);
            Assert.Equal("Добавлен", rezult);
        }

        [Fact]
        public static void UpdateBookGenre_4_4_true_NotNull()
        {
            int genreID = 10;
            int bookID = 10;
            bool choise = true;
            string rezult = bookController.UpdateBookGenre(genreID, bookID, choise);
            Assert.NotNull(rezult);
        }
    }
    
}
