using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using LibMan.Models;
using LibMan.ViewModels;

namespace LibMan.Controllers
{
    public class LendsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LendsController()
        {
            _db = new ApplicationDbContext();
        }


        //GET: Lends
        public ActionResult Index()
        {
            var lends = _db.Lends.Include(l => l.LendDetails.Select(b => b.Book)).ToList();
            return View(lends);
        }


        public ActionResult SelectBorrower()
        {
            var borrowers = _db.Borrowers.ToList();
            return View("SelectBorrower",borrowers);
        }


        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult New(int id)
        {

            var lendFormViewModel = new LendFormViewModel
            {
                Borrower = _db.Borrowers.Single(b=>b.Id==id),
                Books = _db.Books.ToList()
            };
    
            return View("LendForm", lendFormViewModel);
        }


        //public ActionResult Edit(int id)
        //{
        //    var lend = _db.LendBooks.Include(b => b.Book).SingleOrDefault(l => l.Id == id);
        //    if (lend == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var lendBookFormViewModel = new LendBookFormViewModel
        //    {
        //        Borrowers = _db.Borrowers.ToList(),
        //        Books = _db.Books.ToList()
        //    };

        //    return View("LendBookForm", lendBookFormViewModel);
        //}


        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult DeleteLend(int id)
        {
            var lendInDb = _db.Lends.Single(l => l.Id == id);
            if (lendInDb == null)
            {
                HttpNotFound();
            }
            else
            {
                _db.Lends.Remove(lendInDb);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Lends");
        }


        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult DeleteBookFromLend(int id)
        {
            var bookInLend = _db.LendDetails.Single(l => l.Id == id);
            if (bookInLend == null)
            {
                HttpNotFound();
            }
            else
            {
                _db.LendDetails.Remove(bookInLend);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Lends");
        }

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPost]
        public ActionResult Save(Lend lend)
        {
            if (!ModelState.IsValid)
            {
                var lendFormViewModel = new LendFormViewModel
                {
                    Borrower = new Borrower(),
                    Books = _db.Books.ToList()
                };
                return View("LendForm", lendFormViewModel);
            }

            if (lend.Id == 0)
            {
                lend.DateLent = DateTime.Today;
                _db.Lends.Add(lend);
            }
            else //lend.Id != 0
            {
                var lendInDb = _db.Lends.Include(l=>l.LendDetails).Single(l=>l.Id == lend.Id);
                lendInDb.BorrowerId = lend.BorrowerId;
                lendInDb.LendDetails = lend.LendDetails;
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Lends");
        }

    }
}