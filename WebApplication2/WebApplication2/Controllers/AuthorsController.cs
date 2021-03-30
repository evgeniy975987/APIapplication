
using WebApplication2.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication2.data.reposytorys;
using BuisnessLayer;

namespace WebApplication2.Controllers
{


    [Route("newModels/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {



        /// <summary>
        /// метод  AllAuthors() Задание 6.3.1.	Можно получить список всех авторов. (без книг, как и везде, где не указано обратное)
        /// метод AllBookAuthor - возвращает список книг автора 
        /// метод InsertAuthor - 6.3.3.	Добавить автора (с книгами или без) 
        /// DeleteAuthor 6.3.4.	Удалить автора (если только нет книг)
        /// </summary>
        /// <returns></returns>
        /// 
        DataManager _manager;

        public AuthorsController (DataManager manager) {
            _manager = manager;
        }
        [HttpGet]
        public  IEnumerable <string> AllAuthors()
        {
                return _manager._authorRepository.AllAuthors();
        }

        [HttpGet("allBooksAuthor")]
        public IEnumerable<string> AllBookAuthor([FromForm] int AuthorID)
        {
                return _manager._authorRepository.AllBookAuthor(AuthorID);
        }
        
        
        [HttpPost("deleteAuthor")]
        public string DeleteAuthor([FromForm] int AuthorID)
        {
            var rezult = _manager._authorRepository.DeleteAuthor(AuthorID);
            _manager._authorRepository.save();
            return rezult;
            
        }
        [HttpPost("insert")]
        public string InsertAuthor([FromForm] Author author)
        {
            author.DateInsert = DateTime.Now;
            _manager._authorRepository.NewAuthor(author);
            _manager._authorRepository.save();
            return "Добавлен";
        }
        [HttpPost("InsertWithBooks")]
        public string InsertAuthor([FromForm] Author author, [FromForm] Book book, [FromForm] Genre genre)
        {
            author.DateInsert = DateTime.Now;
            author.DateInsert = DateTime.Now;
            _manager._authorRepository.NewAuthor(author, book, genre);
            _manager._authorRepository.save();
            return "Добавлен";
        }

        public  string deleteAuthorCascad(int idAuthor) {
            var rezult = _manager._authorRepository.DeleteAuthorCascad(idAuthor);
            _manager._authorRepository.save();
            return rezult;
        }

        


    }
}

