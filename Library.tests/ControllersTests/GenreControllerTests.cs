using Library.ConrtrollerTests.RepositoryTest;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using Xunit;

namespace Library.tests.ControllersTests
{
    public class GenreControllerTests
    {

        static DataInsertTest _context = new DataInsertTest();
        static GenreRepository _bookRepository = new GenreRepository(_context);
        static GenreController _bookConrtroller = new GenreController(_bookRepository);

        [Fact]
        public static void GetAllGenre_NotEmpty()
        {
            var rezult = _bookConrtroller.GetAllGenre();
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void NewGenre_Notfalse()
        {
            String newGenre = "Тест";
            bool rezult = _bookConrtroller.NewGenre(newGenre);
            Assert.True(rezult);
        }
        [Fact]
        public static void DeleteGenre_Notfalse()
        {
            int genreID = 100;
            bool rezult = _bookConrtroller.DeleteGenre(genreID);
            Assert.True(rezult);
        }

        [Fact]
        public static void GenreStatistic_Notfalse()
        {
            var rezult = _bookConrtroller.Statistic();
            Assert.NotEmpty(rezult);
        }
    }
}
