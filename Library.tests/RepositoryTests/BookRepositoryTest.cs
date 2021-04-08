using BuisnessLayer.Interfaces;
using Library.Insert.Data;
using Moq;
using WebApplication2.data.reposytorys;
using WebApplication2.Entitys;
using Xunit;

namespace Library.RepositoryTests
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
            var rezult = _mock.Object.DeleteBook(bookID);
            
            Assert.NotNull(rezult);
        }

        [Fact]
        public static void NewBook()
        {
            Author author = new Author();
            author.firstName = "����";
            author.middleName = "middle name";
            author.lastName = "Last Name";
            Book book = new Book();
            book.Title = "test";
            Genre genre = new Genre();
            genre.name = "Test";


            _mock.Setup(p => p.NewBook(book, author, genre)).Returns(bookRepository.NewBook(book, author, genre));
            var rezult = _mock.Object.NewBook(book, author, genre);

            
            Assert.Equal("��������", rezult);
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
