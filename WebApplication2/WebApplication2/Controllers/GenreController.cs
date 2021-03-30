using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using WebApplication2.data.reposytorys;
using BuisnessLayer;

namespace WebApplication2.Controllers
{
    [Route("newModels/Genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        DataManager _manager;

        public GenreController(DataManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public  IEnumerable<string> GetAllGenre()
        {
            return _manager._genreRepository.Allgenre();
        }

        [HttpPost]
        public bool NewGenre([FromBody] string genre)
        {
            bool rezult = _manager._genreRepository.NewGenre(genre);
            _manager._genreRepository.Save();
            return rezult;
        }

        [HttpPost]
        public bool DeleteGenre([FromForm] int GenreID)
        {
            var rezult = _manager._genreRepository.DeleteGenre(GenreID);
            _manager._genreRepository.Save();
            return rezult;
        }
        

        
         [HttpGet("GenreStatistic")]
        public IEnumerable <string> GenreStatistic() 
        {
            return _manager._genreRepository.Statistic();
        }
        
    }
}
