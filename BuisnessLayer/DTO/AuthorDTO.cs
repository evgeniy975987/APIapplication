using System;
using System.Collections.Generic;
using WebApplication2.Entitys;

namespace BuisnessLayer.DTO
{
    [Serializable]
    class AuthorDTO
    {


        public int AuthorID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public List<BookDTO> Books { get; set; } = new List<BookDTO>();

        public AuthorDTO(Author author) {
            AuthorID = author.AuthorID;
            firstName = author.firstName;
            middleName = author.middleName;
            lastName = author.lastName;

        }

        public static List<AuthorDTO> ToListAuthorDTO(List<Author> authors) {
            List<AuthorDTO> authorsDTO = new List<AuthorDTO>();
            foreach (Author author in authors) {
                AuthorDTO authorDTO = new AuthorDTO(author);
                authorDTO.AddBooksAuthor(author);
                authorsDTO.Add(authorDTO);
            }
            return authorsDTO;
        }

        public void AddBooksAuthor (Author author) {
            if (author.Books != null) {
                foreach (Book book in author.Books) {
                    Books.Add(new BookDTO(book));
                }
            }
        }
    }

}

