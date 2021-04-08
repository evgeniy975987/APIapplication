
using Library.Insert.Data;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using WebApplication2.Entitys;
using Xunit;

namespace Library.tests.ControllersTests
{
    public class BookControllerTests
    {
        static DataInsertTest _context = new DataInsertTest();
        static BookRepository _bookRepository = new BookRepository(_context);
        static BookController _bookConrtroller = new BookController(_bookRepository);

        [Fact]
        public static void AllBooksAuthor_4_NotEmpty()
        {
            int authorID = 2;

            
            var rezult = _bookRepository.AllBooksAuthor(authorID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void AllBooksGenre_2_NotEmpty()
        {
            int genreID = 2;
            var rezult = _bookConrtroller.AllBooksGenre(genreID);
            Assert.NotEmpty(rezult);
        }

        [Fact]
        public static void DeleteBook_4_NotNull()
        {
            int bookID = 10;
            var rezult = _bookRepository.AllBooksAuthor(bookID);
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void NewBook()
        {
            Author author = new Author();
            author.firstName = "Тест";
            author.middleName = "middle name";
            author.lastName = "Last Name";
            Book book = new Book();
            book.Title = "test";
            Genre genre = new Genre();
            genre.name = "Test";
            var rezult = _bookRepository.NewBook(book, author, genre);
            Assert.Equal("Добавлен", rezult);
        }

        [Fact]
        public static void UpdateBookGenre_4_4_true_NotNull()
        {
            int genreID = 10;
            int bookID = 10;
            bool choise = true;
            var rezult = _bookRepository.UpdateBookGenre(genreID, bookID, choise);
            Assert.NotNull(rezult);
        }

    }
}

