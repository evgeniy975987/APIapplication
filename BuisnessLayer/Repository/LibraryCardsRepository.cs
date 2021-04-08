using BuisnessLayer.DTO;
using BuisnessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using WebApplication2.Entitys;
using Workers;

namespace WebApplication2.data.reposytorys
{

    public class LibraryCardsRepository : ILibraryCardsRepository
    {
        ApplicationContext _context;
        public LibraryCardsRepository(ApplicationContext context) {
            _context = context;
        }
        public  string AllRefund() {
            string json = JsonSerializer.Serialize(LibraryCardsDTO.ToListLibraryCard(_context.LibraryCards.Include(P => P.Person).Include(p => p.Book).ToList<LibraryCards>()));
            return json;
        }
        public  string AllRefundPerson(int personID)
        {
            var person = _context.Persons.Find(personID);
            string json = JsonSerializer.Serialize(LibraryCardsDTO.ToListLibraryCard(_context.LibraryCards.Include(p => p.Book).Include(p => p.Book.Genre).Where(p => p.Person == person).ToList<LibraryCards>()));
            return json;
        }
        public  string ChangeRefund(int bookID, int userID, int days)
        {
            var FindBook = _context.Books.Find(bookID);
            var FindPerson = _context.Persons.Find(userID);
            var FindCard = _context.LibraryCards.Where(p => p.Book == FindBook).Where(P => P.Person == FindPerson).Include(p => p.Book);
            var rezult = _context.LibraryCards.Find(FindCard.First().IDlnk);
            rezult.date_refund = rezult.date_refund.AddDays(days);
            Save();
            return JsonSerializer.Serialize(new LibraryCardsDTO (rezult));
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
