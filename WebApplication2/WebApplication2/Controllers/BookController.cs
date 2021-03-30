using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Workers;
using WebApplication2.Models;

using WebApplication2.data.reposytorys;
using BuisnessLayer;

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

        DataManager _manager;

        public BookController(DataManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public  IEnumerable<string> AllBookAuthor([FromForm] int AuthorID)
        {
                return _manager._bookRepository.AllBooksAuthor(AuthorID); 
        }
        [HttpGet("Genre")]
        public IEnumerable<string> GetAllBooks([FromForm] int genreID )
        {
            return _manager._bookRepository.AllBooksGenre(genreID);
        }
        [HttpDelete("DeleteBook")]
        public string DeleteBook([FromForm] int bookID) {
            string rezult = _manager._bookRepository.DeleteBook(bookID);
            _manager._bookRepository.Save();
            return rezult;
        }
        [HttpPost("newBook")]
        public string NewBook([FromForm] Book book, [FromForm] Author author, [FromForm] Genre genre) {
            book.author = author;
            var rezult = _manager._bookRepository.NewBook(book, author, genre);
            _manager._bookRepository.Save();
            return rezult;
        }

        [HttpPost("updateGenre")]
        public string UpdateBookGenre([FromForm] int GenreID, [FromForm]   int BookID, bool Choise) {
            var rezult = _manager._bookRepository.UpdateBookGenre(GenreID,  BookID, Choise);
            _manager._bookRepository.Save();
            return rezult;
        }

        
        
    }
}
