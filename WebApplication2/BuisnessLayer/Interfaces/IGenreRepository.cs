using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Interfaces
{
    public interface IGenreRepository
    {

        public IEnumerable<string> Allgenre();

        public bool NewGenre(string newGenre);

        public IEnumerable<string> Statistic();
        
        public bool DeleteGenre(int id);


        public void Save();
        
    }
}
