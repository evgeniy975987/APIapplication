using WebApplication2.Entitys;

namespace BuisnessLayer.Interfaces
{
    public interface IBookRepository
    {

        public string NewBook(Book book, Author author, Genre genre);
        public string DeleteBook(int bookID);
        public string UpdateBookGenre(int genreID, int bookID, bool choise);
        public string AllBooksAuthor(int AuthorID);
        public string AllBooksGenre(int genreID);
        public void Save();
       
    }
}
