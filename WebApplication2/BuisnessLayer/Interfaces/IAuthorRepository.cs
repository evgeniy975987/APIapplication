using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Models;

namespace BuisnessLayer.Interfaces
{
    public interface IAuthorRepository
    {

        public IEnumerable<string> AllAuthors();
        public string NewAuthor(Author author);
        
        public string NewAuthor(Author author, Book book, Genre genre);
       
        public string DeleteAuthor(int authorID);
        
        public string DeleteAuthorCascad(int authorID);  

        public IEnumerable<string> FindBooks(int year, bool sort);

        public IEnumerable<string> FindTitleBook(string findText);

        public IEnumerable<string> AllBookAuthor(int authorID);
        public void save();
        
    }
}
