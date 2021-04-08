using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Workers;
using WebApplication2.Entitys;

using WebApplication2.data.reposytorys;
using BuisnessLayer;
using BuisnessLayer.Interfaces;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("newModels/book")]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// метод NewBook - добавить книгу
        /// метод DeleteBook  - удалить книгу но только если она не у пользователя)
        /// метод UpdateBookGenre  -  присвоить новый жанр или удалить ( true - добавить жанр , false - удалить)
        /// AllBookAuthor - получить все книги автора по ID
        /// GetAllBooks - список книг по жанру
        /// </summary>

        IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public  string AllBookAuthor([FromForm] int AuthorID)
        {
                return _bookRepository.AllBooksAuthor(AuthorID); 
        }
        [HttpGet("Genre")]
        public string AllBooksGenre([FromForm] int genreID )
        {
            return _bookRepository.AllBooksGenre(genreID);
        }
        [HttpDelete("DeleteBook")]
        public string DeleteBook([FromForm] int bookID) {
            string rezult = _bookRepository.DeleteBook(bookID);
            return rezult;
        }
        [HttpPost("newBook")]
        public string NewBook([FromForm] Book book, [FromForm] Author author, [FromForm] Genre genre) {
            book.author = author;
            var rezult = _bookRepository.NewBook(book, author, genre);
            return rezult;
        }

        [HttpPost("updateGenre")]
        public string UpdateBookGenre([FromForm] int GenreID, [FromForm]   int BookID, bool Choise) {
            var rezult = _bookRepository.UpdateBookGenre(GenreID,  BookID, Choise);
            return rezult;
        }
    }
}
