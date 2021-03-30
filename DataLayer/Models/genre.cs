
using WebApplication2.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Workers;

namespace WebApplication2.Models
{
    [Table("Genre")]
    public class Genre
    {

        [Column("ID_genre")]
        public int GenreID { get; set; }
        [Column("Genre")]
        public string name { get; set; }
        [Column("date_insert")]
        public DateTimeOffset DateInsert { get; set; }
        [Column("date_update")]
        public DateTimeOffset DateUpdate { get; set; }
        public ICollection<Book> book { get; set; } = new List<Book>();

        }
    }


