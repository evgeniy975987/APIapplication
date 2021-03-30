using BuisnessLayer;
using BuisnessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.data.reposytorys;

namespace WebApplication2.Controllers
{
    [Route("newModels/new_Methods_AuthorController")]
    [ApiController]
    public class NewAuthorController : ControllerBase
    {
        IAuthorRepository _authorRepository;

        public NewAuthorController(IAuthorRepository manager)
        {
            _authorRepository = manager;
        }

        [HttpGet("Find")]
        public IEnumerable<string> FindBooks([FromForm] int year, [FromForm] bool sort)
        {
            // если sort = false - сортровка по алфавиту  если true наоборот
            var rezult = _authorRepository.FindBooks(year, sort);
            return rezult;
        }
        [HttpGet("FindTitle")]
        public IEnumerable<string> FindTitleBook([FromForm] string findText)
        {
            var rezult = _authorRepository.FindTitleBook(findText);
            return rezult;
        }
    }
}
