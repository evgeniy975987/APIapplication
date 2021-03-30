using BuisnessLayer;
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
        DataManager _manager;

        public NewAuthorController(DataManager manager)
        {
            _manager = manager;
        }

        [HttpGet("Find")]
        public IEnumerable<string> FindBook([FromForm] int year, [FromForm] bool sort)
        {
            // если sort = false - сортровка по алфавиту  если true наоборот
            var rezult = _manager._authorRepository.FindBooks(year, sort);
            return rezult;
        }
        [HttpGet("FindTitle")]
        public IEnumerable<string> FindTitleBook([FromForm] string findText)
        {
            var rezult = _manager._authorRepository.FindTitleBook(findText);
            return rezult;
        }
    }
}
