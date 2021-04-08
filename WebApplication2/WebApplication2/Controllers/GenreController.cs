using WebApplication2.Entitys;
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

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        [HttpGet]
        public string GetAllGenre()
        {
            return _genreRepository.Allgenre();
        }

        [HttpPost]
        public bool NewGenre([FromForm] string genre)
        {
            bool rezult = _genreRepository.NewGenre(genre);
            return rezult;
        }

        [HttpDelete("DeleteGenre")]
        public bool DeleteGenre([FromForm] int GenreID)
        {
            var rezult = _genreRepository.DeleteGenre(GenreID);
            return rezult;
        }
        

        
         [HttpGet("GenreStatistic")]
        public string Statistic() 
        {
            return _genreRepository.Statistic();
        }
        
    }
}
