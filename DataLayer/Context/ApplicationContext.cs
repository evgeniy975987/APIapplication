using WebApplication2.Entitys;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using AutoFixture;

namespace Workers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<LibraryCards> LibraryCards { get; set; }
        public DbSet<Person> Persons { get; set; }

        

        public ApplicationContext(DbContextOptions <ApplicationContext> options) : base (options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Genre>().HasKey(p => p.GenreID);
            modelBuilder.Entity<Genre>().HasMany(p => p.book).WithMany(p => p.Genre);
            modelBuilder.Entity<Book>().HasKey(p => p.BookID);
            modelBuilder.Entity<Author>().HasKey(p => p.AuthorID);
            modelBuilder.Entity<Book>().HasOne(p => p.author).WithMany(p => p.Books);
            modelBuilder.Entity<Person>().HasKey(p => p.PersonID);
            modelBuilder.Entity<LibraryCards>().HasKey(p => p.IDlnk);
            modelBuilder.Entity<Person>().HasMany(p => p.LibraryCards).WithOne(p => p.Person);
        }

        


        
    }
}




