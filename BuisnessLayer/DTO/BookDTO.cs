using System;
using System.Collections.Generic;
using WebApplication2.Entitys;

namespace BuisnessLayer.DTO
{
    [Serializable]
    class BookDTO
    {

        public int BookID { get; set; }
        public AuthorDTO author { get; set; }
        public string Title { get; set; }
        public DateTime DateWrite { get; set; }
        public List<GenreDTO> Genres { get; set; } = new List<GenreDTO>();

        public BookDTO(Book book) {
            BookID = book.BookID;
            Title = book.Title;
            DateWrite = book.DateWrite;
            if (book.author != null) 
                author = new AuthorDTO(book.author);
        }
        public static List<BookDTO> ToListBookDTO(List <Book> books) {
            List<BookDTO> BooksDTO = new List<BookDTO>();
            foreach (Book book in books) {
                BookDTO newBookDTO = new BookDTO(book);
                newBookDTO.AddGenresBook(book);
                BooksDTO.Add(newBookDTO);
            }
            return BooksDTO;
        }

        public void AddGenresBook(Book book)
        {
            if (book.Genre != null)
                foreach (Genre genre in book.Genre)
                    Genres.Add(new GenreDTO(genre));
        }
    }
}
