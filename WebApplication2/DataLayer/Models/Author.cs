
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Workers;

namespace WebApplication2.Models

{
    [Table("Authors")]
    public class Author 
    {
        [Column("author_id")]
        public int AuthorID { get; set; }
        [Column("first_name")]
        public string first_name { get; set; }
        [Column("middle_name")]
        public string middle_name { get; set; }
        [Column("last_name")]
        public string last_name { get; set; }
        public ICollection <Book> Books { get; set; }
        [Column("date_insert")]
        public DateTimeOffset DateInsert { get; set; }
        [Column("date_update")]
        public DateTimeOffset DateUpdate { get; set; }

        



    } 
}
