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
    public class PersonRepository : IPersonRepository
    {
        ApplicationContext _context;

        public PersonRepository(ApplicationContext context) {
            _context = context;
        }
        public string NewPerson(DateTime BirthDay, String FirstName, String MiddleName, String LastName)
        {
            _context.Persons.Add(new Person() { BirthDay = BirthDay, DateInsert = DateTime.Now, FirstName = FirstName, LastName = LastName, MiddleName = MiddleName });
            Save();
            return "готово";
        }
        public string ChangePerson(string firstName, string middleName, string lastName, int personID, DateTime BirthDay)
        {
            var person = _context.Persons.Find(personID);
            person.FirstName = firstName;
            person.MiddleName = middleName;
            person.LastName = lastName;
            person.BirthDay = BirthDay;
            person.DateUpdate = DateTime.Now;
            Save();
            return JsonSerializer.Serialize (new PersonDTO(person));
        }
        public bool DeletePerson(int personID)
        {
            bool rezult = false;
            var person = _context.Persons.Find(personID);
            _context.Persons.Remove(person);
            rezult = true;
            Save();
            return rezult;
        }
        public bool DeletePerson(string name, string middleName, string lastName)
        {
            var person = _context.Persons.Where(p => p.FirstName == name).Where(p => p.MiddleName == middleName).Where(p => p.LastName == lastName); ;
            _context.Persons.RemoveRange(person);
            Save();
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
            
            if (CheakRefund > 0) return "Нельзя выдать новую книгу, т.к. есть просроченная";
            else {
                _context.LibraryCards.Add(card);
                Save();
                return "готово";
            }
        }
        public string DeleteLibraryCard(int bookID, int personID)
        {
            var FindPerson = _context.Persons.Find(personID);
            var FindBook = _context.Books.Find(bookID);
            var FindCard = _context.LibraryCards.Where(p => p.Book == FindBook).Where(p => p.Person == FindPerson);
            _context.LibraryCards.Remove(FindCard.First());
            Save();
            return "Готово";
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public string AllbooksPerson(int personID) {
            var FindPerson = _context.Persons.Find(personID);
            string json = JsonSerializer.Serialize(LibraryCardsDTO.ToListLibraryCard(_context.LibraryCards
                .Include(P => P.Person)
                .Include(p => p.Book)
                .Include(p => p.Book.author)
                .Include(p => p.Book.Genre)
                .Where(p => p.Person == FindPerson)
                .ToList<LibraryCards>()));
            return json;
        }
        }
    }

