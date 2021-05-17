using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibMan.Models
{
    public class AssignedBookData
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public bool Assigned { get; set; }
    }
}