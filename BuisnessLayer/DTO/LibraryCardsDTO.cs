using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Entitys;

namespace BuisnessLayer.DTO
{
    [Serializable]
    class LibraryCardsDTO
    {

        public int IDlnk { get; set; }
        public BookDTO Book { get; set; }
        public PersonDTO Person { get; set; }
        public DateTime date_refund { get; set; }

        public LibraryCardsDTO(LibraryCards libraryCards) {
            IDlnk = libraryCards.IDlnk;
            libraryCards.Book.Genre.ToList<Genre>();
            Book = new BookDTO(libraryCards.Book);
            Person = new PersonDTO(libraryCards.Person);
            date_refund = libraryCards.date_refund;

        }

        public static List<LibraryCardsDTO> ToListLibraryCard(List <LibraryCards> libraryCards) {
            List<LibraryCardsDTO> newLibraryCardsDTO = new List<LibraryCardsDTO>();
            foreach (LibraryCards Card in libraryCards) {
                LibraryCardsDTO libraryCardsDTO = new LibraryCardsDTO(Card);
                libraryCardsDTO.Book.AddGenresBook(Card.Book);
                newLibraryCardsDTO.Add(libraryCardsDTO);
            }
            return newLibraryCardsDTO;

        }

    }
}
