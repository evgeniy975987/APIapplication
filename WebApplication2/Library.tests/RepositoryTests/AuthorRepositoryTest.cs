using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2;
using WebApplication2.Models;
using Xunit;
using WebApplication2.data.reposytorys;
using Moq;
using WebApplication2.Controllers;
using Workers;

namespace Library.tests
{
    public class AuthorRepositoryTest
    {

        static Mock<AuthorRepository> Test = new Mock<AuthorRepository>(new ApplicationContext());
        static AuthorsController authorRepository = new AuthorsController(Test.Object);
        static NewAuthorController newAuthorController = new NewAuthorController(Test.Object);

        [Fact]
        public static void AllAuthor_NotEmpty()
        {
            var rezult = authorRepository.AllAuthors();
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void AllBooksAuthor_2_NotEmpty()
        {
            int authorID = 2;
            var rezult = authorRepository.AllBookAuthor(authorID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void DelteAuthor_4_NotNull()
        {
            int authorID = 4;
            var rezult = authorRepository.DeleteAuthor(authorID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void DelteBookAuthor_7_NotNull()
        {
            int authorID = 7;
            var rezult = authorRepository.deleteAuthorCascad(authorID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void FindBook_21_true_NotEmpty()
        {
            int year = 2021;
            bool sort = true;
            var rezult = newAuthorController.FindBook(year, sort);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void FindText_NotEmpty()
        {
            string findText = "BOOK";
            var rezult = newAuthorController.FindTitleBook(findText);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void NewAuthor_newAuthor_equal()
        {
            Author author = new Author();
            author.first_name = "Test";
            author.middle_name = "Test";
            author.last_name = "TEST";
            var rezult = authorRepository.InsertAuthor(author);
            Assert.Equal("Добавлен", rezult);
        }

        [Fact]
        public static void NewAuthor_newAuthor_book_genre_equal()
        {
            Author author = new Author();
            Book book = new Book();
            Genre genre = new Genre();
            var rezult = authorRepository.InsertAuthor(author, book, genre);
            Assert.Equal("Добавлен", rezult);
        }

    }
}
