using WebApplication2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers;
using BuisnessLayer.Interfaces;

namespace WebApplication2.data.reposytorys
{
    public class AuthorRepository : IAuthorRepository
    {
        ApplicationContext _сontext ;
        public AuthorRepository(ApplicationContext context) {
            _сontext = context;
        }
        public  IEnumerable <string> AllAuthors()
        {
                foreach (Author author in _сontext.Authors)
                {
                    yield return author.first_name + "   " + author.middle_name + "   " + author.last_name;
                }
        }
        public  string NewAuthor(Author author)
        {
            author.DateInsert = DateTime.Now;
                _сontext.Authors.Add(author);
            return "Добавлен";
        }
        public  string NewAuthor(Author author, Book book, Genre genre)
        {
            book.author = author;
            book.Genre.Add(genre);
            genre.book.Add(book);
            
            _сontext.Authors.Add(author);
            _сontext.Books.Add(book);
            _сontext.Genres.Add(genre);
            return "Добавлен";
        }
        public  string DeleteAuthor(int authorID )
        {
                var FindAuthor = _сontext.Authors.Find(authorID);
                var FindBookAuthor = _сontext.Books.Find(FindAuthor.AuthorID);
            if (FindBookAuthor == null)
            {
                _сontext.Authors.Remove(FindAuthor);
                return "удалён";
            }
            else return "Нельзя удалить, в библиотеке есть книги этого автора";
        }
        public string DeleteAuthorCascad(int authorID)
        {
                var FindAuthor = _сontext.Authors.Find(authorID);
                var FindBookAuthor = _сontext.Books.Where(p => p.author == FindAuthor);
            string rezult = null;
            foreach (Book book in FindBookAuthor)
            {
                var findCard = _сontext.LibraryCards.Where(p => p.Book == book);
                if (findCard != null) {
                    rezult = "нельзя удалить автора и его книги, т.к. книга автора находится у пользователя";
                    break;
                }
            }
            if (rezult == null)
            {
                _сontext.Authors.Remove(FindAuthor);
                _сontext.Books.RemoveRange(FindBookAuthor);
                rezult = "Готово";
            }
            return rezult;
        }
        public IEnumerable<string> FindBooks(int year, bool sort)
        {
            IQueryable<Book> name;
            if (sort != false) name = _сontext.Books.Where(p => p.DateWrite.Year == year).OrderByDescending(p => p.Title);
            else name = _сontext.Books.Where(p => p.DateWrite.Year == year).OrderBy(p => p.Title);
            foreach (Book book in name) 
                yield return book.Title;
        }
        public  IEnumerable <string> FindTitleBook(string findText)
        {
            var test = _сontext.Books.Where(p => p.Title.ToLower().Contains(findText.ToLower()));
            foreach (Book book in test) 
                yield return "Название книги: " + book.Title + " автор: " + book.author.first_name;
        }
        public  IEnumerable<string> AllBookAuthor(int authorID) {
                var FindAuthor = _сontext.Authors.Find(authorID);
                var FindBooks = _сontext.Books.Where(p => p.author == FindAuthor);
                foreach (Book book in FindBooks) 
                    yield return book.DateWrite + "  " + book.Title;
        }
        public void save()
        {
            _сontext.SaveChanges();
        }
    }
}
