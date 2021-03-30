using WebApplication2.Models;


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers;
using BuisnessLayer.Interfaces;

namespace WebApplication2.data.reposytorys
{
    public class GenreRepository : IGenreRepository
    {
        ApplicationContext _Context;


        public GenreRepository(ApplicationContext context) {
            _Context = context;
        }
        public  IEnumerable <string> Allgenre()
        {
            foreach (Genre genre in _Context.Genres)
                yield return genre.name;
        }
        public  bool NewGenre(string  newGenre)
        {
            try
            {
                _Context.Genres.Add(new Genre() { name = newGenre, DateInsert = DateTime.Now });
                return true;
            }

            catch {
                return false;
            }
        }
        public IEnumerable<string> Statistic() {
            foreach (Genre genre in _Context.Genres.Include(t => t.book)) {
                yield return "Количество книг: " + genre.book.Count() +" Жанр: " + genre.name;
            }
        }
        public bool DeleteGenre(int id) {
            var FindGenre = _Context.Genres.Find(id);
            try {
                _Context.Genres.Remove(FindGenre);
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
