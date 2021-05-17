using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibMan.Models;

namespace LibMan.ViewModels
{
    public class LendFormViewModel
    {
        public Lend Lend { get; set; }

        public LendDetail LendDetail { get; set; }
        public Borrower Borrower { get; set; }
        public IEnumerable<Book> Books { get; set; }
       
    }
}