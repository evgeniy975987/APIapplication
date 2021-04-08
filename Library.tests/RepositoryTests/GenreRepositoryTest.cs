using BuisnessLayer.Interfaces;
using Library.Insert.Data;
using Moq;
using System;
using WebApplication2.data.reposytorys;
using Xunit;

namespace Library.RepositoryTests
{
    public class GenreRepositoryTest {

        static DataInsertTest _context = new DataInsertTest();
        static Mock<IGenreRepository> _mock = new Mock<IGenreRepository>();

        static GenreRepository _genreRepository = new GenreRepository(_context);

        [Fact]
        public static void GetAllGenre_NotEmpty()
        {
            _mock.Setup(p => p.Allgenre()).Returns(_genreRepository.Allgenre());
            var rezult = _mock.Object.Allgenre();


            
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void NewGenre_Notfalse()
        {
            String newGenre = "Тест";

            _mock.Setup(p => p.NewGenre(newGenre)).Returns(_genreRepository.NewGenre(newGenre));
            bool rezult = _mock.Object.NewGenre(newGenre);
            
            Assert.True(rezult);
        }

        [Fact]
        public static void DeleteGenre_Notfalse()
        {
            int genreID = 100;

            _mock.Setup(p => p.DeleteGenre(genreID)).Returns(_genreRepository.DeleteGenre(genreID));
            bool rezult = _mock.Object.DeleteGenre(genreID);
            Assert.True(rezult);
        }

        [Fact]
        public static void GenreStatistic_Notfalse()
        {
            _mock.Setup(p => p.Statistic()).Returns(_genreRepository.Statistic());
            var rezult = _mock.Object.Statistic();
            Assert.NotEmpty(rezult);
        }
        


    }
}
