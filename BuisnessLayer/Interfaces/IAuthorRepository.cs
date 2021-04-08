using WebApplication2.Entitys;

namespace BuisnessLayer.Interfaces
{
    public interface IAuthorRepository
    {

        public string AllAuthors();
        public string NewAuthor(Author author);
        public string NewAuthor(Author author, Book book, Genre genre);
        public string DeleteAuthor(int authorID);
        public string DeleteAuthorCascad(int authorID);  
        public string FindBooks(int year, bool sort);
        public string FindTitleBook(string findText);
        public string AllBookAuthor(int authorID);
        public void save();
        
    }
}
