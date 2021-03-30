
using WebApplication2.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication2.data.reposytorys;
using BuisnessLayer;
using BuisnessLayer.Interfaces;

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
        IAuthorRepository _authorRepository;

        public AuthorsController (IAuthorRepository manager) {
            _authorRepository = manager;
        }
        [HttpGet]
        public  IEnumerable <string> AllAuthors()
        {
                return _authorRepository.AllAuthors();
        }

        [HttpGet("allBooksAuthor")]
        public IEnumerable<string> AllBookAuthor([FromForm] int AuthorID)
        {
                return _authorRepository.AllBookAuthor(AuthorID);
        }
        
        
        [HttpPost("deleteAuthor")]
        public string DeleteAuthor([FromForm] int AuthorID)
        {
            var rezult = _authorRepository.DeleteAuthor(AuthorID);
            _authorRepository.save();
            return rezult;
            
        }
        [HttpPost("insert")]
        public string NewAuthor([FromForm] Author author)
        {
            author.DateInsert = DateTime.Now;
            _authorRepository.NewAuthor(author);
            _authorRepository.save();
            return "Добавлен";
        }
        [HttpPost("InsertWithBooks")]
        public string NewAuthor([FromForm] Author author, [FromForm] Book book, [FromForm] Genre genre)
        {
            author.DateInsert = DateTime.Now;
            author.DateInsert = DateTime.Now;
            _authorRepository.NewAuthor(author, book, genre);
            _authorRepository.save();
            return "Добавлен";
        }

        public  string deleteAuthorCascad(int idAuthor) {
            var rezult = _authorRepository.DeleteAuthorCascad(idAuthor);
            _authorRepository.save();
            return rezult;
        }

        


    }
}

