﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using WebApplication2.Models;

namespace WebApplication2.Models
{
    
    public class LibraryCards
    {
        public int IDlnk { get; set; }
        public Book Book{ get; set; }
        public Person Person { get; set; }
        public DateTime date_refund { get; set; }
    }
}
