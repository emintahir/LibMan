﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibMan.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}