using BuisnessLayer.Interfaces;
using Library.ConrtrollerTests.RepositoryTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using WebApplication2.Models;
using Xunit;

namespace Library.tests.ControllersTests
{
    public class AuthorsControllerTests
    {

        static DataInsertTest _context = new DataInsertTest();
        static AuthorRepository _authorRepository = new AuthorRepository(_context);
        static AuthorsController _authorsController = new AuthorsController(_authorRepository);
        [Fact]
        public static void AllAuthor_NotEmpty()
        {
            var rezult = _authorsController.AllAuthors();
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void AllBooksAuthor_2_NotEmpty()
        {
            int authorID = 2;
            var rezult = _authorRepository.AllBookAuthor(authorID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void DelteAuthor_4_NotNull()
        {
            int authorID = 4;
            var rezult = _authorRepository.DeleteAuthor(authorID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void DelteBookAuthor_7_NotNull()
        {
            int authorID = 7;
            var rezult = _authorRepository.DeleteAuthorCascad(authorID);
            Assert.NotNull(rezult);
        }
        [Fact]
        public static void NewAuthor_newAuthor_equal()
        {
            Author author = new Author();
            author.first_name = "Test";
            author.middle_name = "Test";
            author.last_name = "TEST";
            var rezult = _authorRepository.NewAuthor(author);
            Assert.Equal("Добавлен", rezult);
        }

        [Fact]
        public static void NewAuthor_newAuthor_book_genre_equal()
        {
            Author author = new Author();
            Book book = new Book();
            Genre genre = new Genre();
            var rezult = _authorRepository.NewAuthor(author, book, genre);
            _authorRepository.save();
            Assert.Equal("Добавлен", rezult);

        }
    }
}
