using BuisnessLayer.DTO;
using BuisnessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using WebApplication2.Entitys;
using Workers;

namespace WebApplication2.data.reposytorys
{
    public class BookRepository : IBookRepository
    {
        ApplicationContext _context;

        public BookRepository(ApplicationContext context) {
            _context = context;
        }

        public string NewBook(Book book, Author author, Genre genre)
        {
            book.author = author;
            book.Genre.Add(genre);
            _context.Authors.Add(author);
            _context.Books.Add(book);
            _context.Genres.Add(genre);
            Save();
            return "Добавлен";
        }
        public string DeleteBook(int bookID)
        {
            var FindBook = _context.Books.Find(bookID);
            var Cheak = _context.LibraryCards.Where(p => p.Book == FindBook).FirstOrDefault();
            if (Cheak == null)
            {
                _context.Books.Remove(FindBook);
                Save();
                return "Готово";
            }
            else return "нельзя удалить, т.к. книга находиться у пользователя";
        }
        public string UpdateBookGenre(int genreID,  int bookID, bool create)
        {
            var FindGenre = _context.Genres.Find(genreID);
            var include = _context.Books.Where(p => p.BookID == bookID).Include(p => p.Genre).Include(p => p.author);
            var findBook = include.Where(p => p.BookID == bookID).Where(p => p.BookID == bookID).FirstOrDefault();
           
            if (create == true)
            {
                findBook.Genre.Add(FindGenre);
                Save();
                return "Добавлен";
            }
            else {
                findBook.Genre.Remove(FindGenre);
                _context.Genres.Remove(FindGenre);
                Save();
                return "Удалён";
            }
        }
        public string AllBooksAuthor(int AuthorID)
        {
            var FindAuthor = _context.Authors.Find(AuthorID);
            var FindBooks = _context.Books.Include(p => p.Genre).Where(p => p.author == FindAuthor).ToList<Book>();
            string json = JsonSerializer.Serialize(BookDTO.ToListBookDTO(FindBooks));
            return json;
        }
        public string AllBooksGenre(int genreID)
        {
            var FindGenre = _context.Genres.Where(p => p.GenreID == genreID).Include(p => p.book).ToList<Genre>() ;
            string json = JsonSerializer.Serialize(GenreDTO.ToListGenreDTO(FindGenre));
            return json;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
