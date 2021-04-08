using BuisnessLayer.Interfaces;
using Library.Insert.Data;
using Moq;
using WebApplication2.data.reposytorys;
using WebApplication2.Entitys;
using Xunit;

namespace Library.RepositoryTests

{
    public class AuthorRepositoryTest 
    {

        static DataInsertTest _context = new DataInsertTest();
        static Mock<IAuthorRepository> _mock = new Mock<IAuthorRepository>();
        static AuthorRepository authorRepository = new AuthorRepository(_context);




        [Fact]
        public static void AllAuthor_NotEmpty()
        {
            _mock.Setup(p => p.AllAuthors()).Returns(authorRepository.AllAuthors);
            var rezult = _mock.Object.AllAuthors();
            Assert.NotEmpty(rezult);
        }


        [Fact]
        public static void AllBooksAuthor_2_NotEmpty()
        {
            int authorID = 2;
            _mock.Setup(p => p.AllBookAuthor(authorID)).Returns(authorRepository.AllBookAuthor(authorID));
            var rezult = _mock.Object.AllBookAuthor(authorID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void DelteAuthor_4_NotNull()
        {
            int authorID = 4;
            _mock.Setup(p => p.DeleteAuthor(authorID)).Returns(authorRepository.DeleteAuthor(authorID));
            
            var rezult = _mock.Object.DeleteAuthor(authorID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void DelteBookAuthor_7_NotNull()
        {
            int authorID = 7;
            _mock.Setup(p => p.DeleteAuthorCascad(authorID)).Returns(authorRepository.DeleteAuthorCascad(authorID));

            var rezult = _mock.Object.DeleteAuthorCascad(authorID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void FindBook_21_true_NotEmpty()
        {
            int year = 1857;
            bool sort = true;

            _mock.Setup(p => p.FindBooks(year, sort)).Returns(authorRepository.FindBooks(year, sort));
            var rezult = _mock.Object.FindBooks(year, sort);

           
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void FindText_NotEmpty()
        {
            string findText = "ДАТА";
            _mock.Setup(p => p.FindTitleBook(findText)).Returns(authorRepository.FindTitleBook(findText));

            var rezult = _mock.Object.FindTitleBook(findText);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void NewAuthor_newAuthor_equal()
        {
            Author author = new Author();
            author.firstName = "Test";
            author.middleName = "Test";
            author.lastName = "TEST";

            _mock.Setup(p => p.NewAuthor(author)).Returns(authorRepository.NewAuthor(author));
            var rezult = _mock.Object.NewAuthor(author);
            
            Assert.Equal("Добавлен", rezult);
        }

        [Fact]
        public static void NewAuthor_newAuthor_book_genre_equal()
        {
            Author author = new Author();
            Book book = new Book();
            Genre genre = new Genre();

            _mock.Setup(p => p.NewAuthor(author, book, genre)).Returns(authorRepository.NewAuthor(author, book, genre));
            var rezult = _mock.Object.NewAuthor(author, book, genre);
            _mock.Object.save();
            Assert.Equal("Добавлен", rezult);

        }


    }
}
