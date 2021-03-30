using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using WebApplication2.data.reposytorys;
using BuisnessLayer;
using BuisnessLayer.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("newModels/Genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        IGenreRepository _genreRepository;

        public GenreController(IGenreRepository manager)
        {
            _genreRepository = manager;
        }
        [HttpGet]
        public  IEnumerable<string> GetAllGenre()
        {
            return _genreRepository.Allgenre();
        }

        [HttpPost]
        public bool NewGenre([FromBody] string genre)
        {
            bool rezult = _genreRepository.NewGenre(genre);
            _genreRepository.Save();
            return rezult;
        }

        [HttpPost]
        public bool DeleteGenre([FromForm] int GenreID)
        {
            var rezult = _genreRepository.DeleteGenre(GenreID);
            _genreRepository.Save();
            return rezult;
        }
        

        
         [HttpGet("GenreStatistic")]
        public IEnumerable <string> Statistic() 
        {
            return _genreRepository.Statistic();
        }
        
    }
}
