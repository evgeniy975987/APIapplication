using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entitys;
using Workers;

namespace Library.Insert.Data
{
    
    public class DataInsertTest : ApplicationContext
    {
        
        public DataInsertTest() : base (new DbContextOptions<ApplicationContext>() ) {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            Database.Migrate();
            TestInsert();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = memory2.db");
        }
        public  void TestInsert()
        {

            for (int i = 0; i < 200; i++)
            {
                Random random = new Random();
                Book book = new Book();
                book.DateInsert = DateTimeOffset.Now;
                book.DateUpdate = DateTimeOffset.Now;
                book.DateWrite = new DateTime(1857 + i, random.Next(1, 12), random.Next(1, 28));
                book.Title = "дата издания " + book.DateWrite;

                Author author = new Author();
                var fixture = new Fixture();
                author.firstName = new Fixture().Create<string>();
                author.middleName = new Fixture().Create<string>();
                author.lastName = new Fixture().Create<string>();
                author.DateInsert = DateTimeOffset.Now;
                author.DateUpdate = DateTime.Now;

                Genre genre = new Genre();
                genre.name = new Fixture().Create<string>();
                genre.DateInsert = DateTimeOffset.Now;
                genre.DateUpdate = DateTimeOffset.Now;


                LibraryCards libraryCards = new LibraryCards();
                libraryCards.date_refund = DateTime.Now.AddDays(7);

                Person person = new Person();
                person.FirstName = new Fixture().Create<string>();
                person.MiddleName = new Fixture().Create<string>();
                person.LastName = new Fixture().Create<string>();

                book.Genre.Add(genre);
                book.author = author;
                genre.book.Add(book);
                libraryCards.Book = book;
                libraryCards.Person = person;

                this.Books.Add(book);
                Genres.Add(genre);
                LibraryCards.Add(libraryCards);
                Persons.Add(person);
                Authors.Add(author);
                SaveChanges();
            }

        }
    }
     
}
