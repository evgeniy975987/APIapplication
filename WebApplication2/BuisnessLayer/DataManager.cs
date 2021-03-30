using BuisnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer
{
    public class DataManager
    {
        public IAuthorRepository _authorRepository;
        public IBookRepository _bookRepository;
        public IGenreRepository _genreRepository;
        public ILibraryCardsRepository _libraryCardsRepository;
        public IPersonRepository _personRepository;

        public DataManager(IAuthorRepository authorRepository, IBookRepository bookRepository, IGenreRepository genreRepository, ILibraryCardsRepository libraryCardsRepository, IPersonRepository personRepository) {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _libraryCardsRepository = libraryCardsRepository;
            _personRepository = personRepository;
        }

    }
}
