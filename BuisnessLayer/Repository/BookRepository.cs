using WebApplication2.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Workers;
using BuisnessLayer.Interfaces;

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
            return "Добавлен";
        }
        public string DeleteBook(int bookID)
        {
            var FindBook = _context.Books.Find(bookID);
            var Cheak = _context.LibraryCards.Where(p => p.Book == FindBook).FirstOrDefault();
            if (Cheak == null)
            {
                _context.Books.Remove(FindBook);
                return "Готово";
            }
            else return "нельзя удалить, т.к. книга находиться у пользователя";
        }
        public string UpdateBookGenre(int genreID,  int bookID, bool choise)
        {
            var FindGenre = _context.Genres.Find(genreID);
            var include = _context.Books.Where(p => p.BookID == bookID).Include(p => p.Genre).Include(p => p.author);
            var findBook = include.Where(p => p.BookID == bookID).Where(p => p.BookID == bookID).FirstOrDefault();
           
            if (choise == true)
            {
                findBook.Genre.Add(FindGenre);
                return "Добавлен";
            }
            else {
                findBook.Genre.Remove(FindGenre);
                _context.Genres.Remove(FindGenre);
                return "Удалён";
            }
        }
        public IEnumerable<string> AllBooksAuthor(int AuthorID)
        {
            var FindAuthor = _context.Authors.Find(AuthorID);
            var FindBooks = _context.Books.Where(p => p.author == FindAuthor);
            foreach (Book book in FindBooks)
                yield return FindAuthor.first_name + "   " + FindAuthor.middle_name + "   " + FindAuthor.last_name + book.Title + book.BookID;
        }
        public IEnumerable<string> AllBooksGenre(int genreID)
        {
            var FindGenre = _context.Genres.Where(p => p.GenreID == genreID).Include(p => p.book).First() ;
            foreach (Book book in FindGenre.book)
            {
                yield return "Количество книг: " + FindGenre.book.Count() + " Название книги: " + FindGenre.name;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
