namespace BuisnessLayer.Interfaces
{
    public interface IGenreRepository
    {
        public string Allgenre();
        public bool NewGenre(string newGenre);
        public string Statistic();
        public bool DeleteGenre(int id);
        public void Save();
        
    }
}
