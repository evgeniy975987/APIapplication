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
    public class GenreRepositoryTest {

        static Mock<GenreRepository> Test = new Mock<GenreRepository>(new ApplicationContext());
        static GenreController genreController = new GenreController(Test.Object);

        [Fact]
        public static void GetAllGenre_NotEmpty()
        {
            var rezult = genreController.GetAllGenre(); 
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void NewGenre_Notfalse()
        {
            bool rezult = genreController.NewGenre("Тест");
            Assert.True(rezult);
        }

        [Fact]
        public static void DeleteGenre_Notfalse()
        {
            bool rezult = genreController.DeleteGenre(212);
            Assert.True(rezult);
        }

        [Fact]
        public static void GenreStatistic_Notfalse()
        {
            var rezult = genreController.GenreStatistic();
            Assert.NotEmpty(rezult);
        }



    }
}
