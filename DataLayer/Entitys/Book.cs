using WebApplication2.Entitys;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

using System.Linq;
using System.ComponentModel.DataAnnotations;
using Workers;

namespace WebApplication2.Entitys
{
    [Table("Books")]
    public class Book
    {
        [Column("ID_book")]
        public int BookID { get; set; }
        public Author author { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("Date_Write")]
        public DateTime DateWrite { get; set; }

        [Column("date_insert")]
        public DateTimeOffset DateInsert { get; set; }

        [Column("date_update")]
        public DateTimeOffset DateUpdate { get; set; }
        public ICollection<Genre> Genre { get; set; } = new List<Genre>();
    }
}
