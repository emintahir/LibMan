using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace LibMan.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [Display(Name = "Date Published")]
        public int? YearPublished { get; set; }

        [Required]
        public DateTime DateAddedToLibrary { get; set; }

        public string BookLocAtLibrary { get; set; }

        public string ImageAddress { get; set; }

        [Display(Name = "Number of Pages")]
        public int? Page { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public virtual ICollection<LendDetail> LendDetails { get; set; }

        public virtual Category Category { get; set; }

    }
}