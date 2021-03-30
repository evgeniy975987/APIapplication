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
    
    public class LibraryCardsRepository : ILibraryCardsRepository
    {
        ApplicationContext _context;
        public LibraryCardsRepository(ApplicationContext context) {
            _context = context;
        }
        public  IEnumerable<string> AllRefund() {
            foreach (LibraryCards card in _context.LibraryCards.Include(P => P.Person).Include(p => p.Book)) {
                yield return card.date_refund + card.Person.MiddleName + "   " + card.Person.LastName + "   " + card.Person.LastName;
            }
        }
        public  IEnumerable <string> AllRefundPerson(int personID)
        {
            var person = _context.Persons.Find(personID);
            foreach (LibraryCards card in _context.LibraryCards.Where(p => p.Person == person))
                yield return card.date_refund + "   " + card.Person.FirstName + "   " + card.Person.MiddleName + "   " + card.Person.LastName;
        }
        public  string ChangeRefund(int bookID, int userID, int days)
        {
                var FindBook = _context.Books.Find(bookID);
                var FindPerson = _context.Persons.Find(userID);
                var FindCard = _context.LibraryCards.Where(p => p.Book == FindBook).Where(P => P.Person == FindPerson).Include(p => p.Book);
            var rezult = _context.LibraryCards.Find(FindCard.First().IDlnk);
            rezult.date_refund = rezult.date_refund.AddDays(days);
            return "Изменено";
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
