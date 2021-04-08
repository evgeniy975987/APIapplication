using BuisnessLayer.DTO;
using BuisnessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using WebApplication2.Entitys;
using Workers;

namespace WebApplication2.data.reposytorys
{
    public class GenreRepository : IGenreRepository
    {
        ApplicationContext _Context;


        public GenreRepository(ApplicationContext context) {
            _Context = context;
        }
        public  string Allgenre()
        {
            string json = JsonSerializer.Serialize(GenreDTO.ToListGenreDTO(_Context.Genres.ToList<Genre>()));
            return json;
        }
        public  bool NewGenre(string  newGenre)
        {
            try
            {
                _Context.Genres.Add(new Genre() { name = newGenre, DateInsert = DateTime.Now });
                Save();
                return true;
            }
            catch {
                return false;
            }
        }
        public string Statistic() {
            string json = JsonSerializer.Serialize(GenreDTO.ToListGenreDTO(_Context.Genres.Include(t => t.book).ToList<Genre>()));
            return json;
        }
        public bool DeleteGenre(int id) {
            var FindGenre = _Context.Genres.Find(id);
            try {
                _Context.Genres.Remove(FindGenre);
                Save();
                return true;
            }
            catch {
                return false;
            }
            
        }
        public void Save()
        {
            _Context.SaveChanges();
        }

    }
}
