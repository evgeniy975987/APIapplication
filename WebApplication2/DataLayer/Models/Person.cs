using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Workers;

namespace WebApplication2.Models
{
    [Table("Persons")]
    public class Person
    {

        [Column("person_id")]
        public int PersonID { get; set; }

        [Column("birth_date")]
        public DateTime BirthDay { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_Name")]
        public string LastName { get; set; }


        [Column("date_insert")]
        public DateTimeOffset DateInsert { get; set; }

        [Column("date_update")]
        public DateTimeOffset DateUpdate { get; set; }
        public ICollection <LibraryCards> LibraryCards { get; set; }
        


       

        
    }
}
