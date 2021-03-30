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
    public class PersonRepository : IPersonRepository
    {
        ApplicationContext _context;

        public PersonRepository(ApplicationContext context) {
            _context = context;
        }
        public string NewPerson(DateTime BirthDay, String FirstName, String MiddleName, String LastName)
        {
            _context.Persons.Add(new Person() { BirthDay = BirthDay, DateInsert = DateTime.Now, FirstName = FirstName, LastName = LastName, MiddleName = MiddleName });
            return "готово";
        }
        public string ChangePerson(string firstName, string middleName, string lastName, int personID, DateTime BirthDay)
        {
            var pers = _context.Persons.Find(personID);
            pers.FirstName = firstName;
            pers.MiddleName = middleName;
            pers.LastName = lastName;
            pers.BirthDay = BirthDay;
            pers.DateUpdate = DateTime.Now;
            return "Изменено на " + pers.FirstName + "   " + pers.MiddleName + "    " + pers.LastName;
        }
        public bool deletePerson(int personID)
        {
            bool rezult = false;
            var person = _context.Persons.Find(personID);
            _context.Persons.Remove(person);
            rezult = true;
            return rezult;
        }
        public bool deletePerson(string name, string middleName, string lastName)
        {
            
            var person = _context.Persons.Where(p => p.FirstName == name).Where(p => p.MiddleName == middleName).Where(p => p.LastName == lastName); ;
            _context.Persons.RemoveRange(person);
            
            return true;
        }
        public string NewLibraryCard(int personID, int bookID)
        {
            var FindPerson = _context.Persons.Find(personID);
            var FindBook = _context.Books.Find(bookID);
            var FindLibraryCard = _context.LibraryCards.Where(p => p.Person == FindPerson);
            var CheakRefund = FindLibraryCard.Where(p => p.date_refund < DateTime.Now).Count();

            LibraryCards card = new LibraryCards()
            {
                Book = FindBook,
                date_refund = DateTime.Now.AddDays(7),
                Person = FindPerson
            };
            
            _context.LibraryCards.Add(card);
            
            
            if (CheakRefund > 0) return "Нельзя выдать новую книгу, т.к. есть просроченная";
            else return "готово";
        }
        public string DeleteLibraryCard(int bookID, int personID)
        {
            var FindPerson = _context.Persons.Find(personID);
            var FindBook = _context.Books.Find(bookID);
            var FindCard = _context.LibraryCards.Where(p => p.Book == FindBook).Where(p => p.Person == FindPerson);
            _context.LibraryCards.Remove(FindCard.First());
            return "Готово";
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        
        public IEnumerable<string> AllbooksPerson(int personID) {
            var FindPerson = _context.Persons.Find(personID);
            foreach (LibraryCards card in _context.LibraryCards.Where(p => p.Person == FindPerson).Include(P => P.Person).Include(p => p.Book).Include(p => p.Book.author))
            {
                yield return card.date_refund +
                    "   " + card.Person.MiddleName + 
                    "   " + card.Person.LastName + 
                    "   " + card.Person.LastName +
                    " название книги  " + card.Book.Title +
                    " имя автора " + card.Book.author.first_name +
                    " фамилия автора  " + card.Book.author.last_name +
                    " отчество автор  " + card.Book.author.last_name;
            }
            }
        }
    }

