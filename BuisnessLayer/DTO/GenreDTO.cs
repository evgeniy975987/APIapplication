using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Entitys;

namespace BuisnessLayer.DTO
{
    [Serializable]
    class GenreDTO
    {


        public int GenreID { get; set; }
        public string Name { get; set; }
        public List<BookDTO> Books { get; set; } = new List<BookDTO>();


        public  GenreDTO(Genre genre) {
            GenreID = genre.GenreID;
            Name = genre.name;
            
        }

        public GenreDTO() { }

        public static List<GenreDTO> ToListGenreDTO(List<Genre> genres) {
            List<GenreDTO> genresDTO = new List<GenreDTO>();
            foreach (Genre genre in genres) {
                GenreDTO newGenreDTO = new GenreDTO(genre);
                newGenreDTO.AddBook(genre.book.ToList<Book>());
                genresDTO.Add(newGenreDTO);
            }
            return genresDTO;
        }

        public void AddBook(List <Book> books) {
            if (books != null)
            {
                foreach (Book book in books)
                {
                    Books.Add(new BookDTO(book));
                }
            }



        }
    }
}
