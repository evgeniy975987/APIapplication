using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Models;

namespace BuisnessLayer.Interfaces
{
    public interface IBookRepository
    {

        public string NewBook(Book book, Author author, Genre genre);
        public string DeleteBook(int bookID);
        public string UpdateBookGenre(int genreID, int bookID, bool choise);
        public IEnumerable<string> AllBooksAuthor(int AuthorID);
        public IEnumerable<string> AllBooksGenre(int genreID);
        public void Save();
       
    }
}
