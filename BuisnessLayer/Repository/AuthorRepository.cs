using BuisnessLayer.DTO;
using BuisnessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebApplication2.Entitys;
using Workers;

namespace WebApplication2.data.reposytorys
{
    public class AuthorRepository : IAuthorRepository
    {
        ApplicationContext _сontext ;
        public AuthorRepository(ApplicationContext context) {
            _сontext = context;
        }
        public  string AllAuthors()
        {

            string json = JsonSerializer.Serialize(_сontext.Authors.ToList<Author>());
            return json;
        }
        public  string NewAuthor(Author author)
        {
            author.DateInsert = DateTime.Now;
                _сontext.Authors.Add(author);
            save();
            return JsonSerializer.Serialize(author);
        }
        public  string NewAuthor(Author author, Book book, Genre genre)
        {
            book.author = author;
            book.Genre.Add(genre);
            
            
            _сontext.Authors.Add(author);
            _сontext.Books.Add(book);
            _сontext.Genres.Add(genre);
            save();
            return JsonSerializer.Serialize(new AuthorDTO (author));
        }
        public  string DeleteAuthor(int authorID )
        {
                var FindAuthor = _сontext.Authors.Find(authorID);
                var FindBookAuthor = _сontext.Books.Find(FindAuthor.AuthorID);
            if (FindBookAuthor == null)
            {
                _сontext.Authors.Remove(FindAuthor);
                save();
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
                save();
            }
            return rezult;
        }
        public string FindBooks(int year, bool sort)
        {
            List<Book> Books;
            if (sort != false) Books = _сontext.Books.Where(p => p.DateWrite.Year == year).OrderByDescending(p => p.Title).ToList<Book>();
            else Books = _сontext.Books.Where(p => p.DateWrite.Year == year).OrderBy(p => p.Title).ToList<Book>();
            string json = JsonSerializer.Serialize(BookDTO.ToListBookDTO(Books));
            return json;
        }
        public  string FindTitleBook(string findText)
        {
            var Books = _сontext.Books.Include(p => p.author).Where(p => p.Title.ToLower().Contains(findText.ToLower())).ToList<Book>();
            string json = JsonSerializer.Serialize(BookDTO.ToListBookDTO(Books));
            return json;
        }
        public  string AllBookAuthor(int authorID) {
                var FindAuthor = _сontext.Authors.Find(authorID);
                var FindBooks = _сontext.Books.Include(p => p.Genre).Where(p => p.author == FindAuthor).ToList<Book>();
            string json = JsonSerializer.Serialize(BookDTO.ToListBookDTO(FindBooks));
            return json;
        }
        public void save()
        {
            _сontext.SaveChanges();
        }
    }
}
