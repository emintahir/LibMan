using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibMan.Models
{
    public class Lend
    {
        public int Id { get; set; }
        public int BorrowerId { get; set; }

        public DateTime DateLent { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual Borrower Borrower { get; set; }

        public virtual ICollection<LendDetail> LendDetails { get; set; }

    }
}