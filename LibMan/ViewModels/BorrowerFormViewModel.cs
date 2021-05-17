using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibMan.Models;

namespace LibMan.ViewModels
{
    public class BorrowerFormViewModel
    {
        public Borrower Borrower { get; set; }

        public string BorrowerFormPageTitle
        {
            get
            {
                if (Borrower != null && Borrower.Id !=0)
                {
                    return "Edit Borrower";
                }
                else
                { 
                    return "New Borrower";
                }
            }
        }
    }
}