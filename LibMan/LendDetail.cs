using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibMan.Models;

namespace LibMan
{
    public class LendDetail
    {
        public int Id { get; set; }
        public int LendId { get; set; }
        public int BookId { get; set; }
        public Lend Lend { get; set; }
        public Book Book { get; set; }

    }
}