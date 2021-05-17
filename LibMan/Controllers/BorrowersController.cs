using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibMan.Models;
using LibMan.ViewModels;

namespace LibMan.Controllers
{
    public class BorrowersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BorrowersController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }


        // GET: Borrower
        public ActionResult Index()
        {
            var borrowers = _db.Borrowers.ToList();
            return View(borrowers);
        }

        public ActionResult Details(int id)
        {
            var borrower = _db.Borrowers.SingleOrDefault(b=>b.Id==id);
            if (borrower==null)
            {
                return HttpNotFound();
            }

            return View(borrower);
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult New()
        {
            var borrowerFormViewModel = new BorrowerFormViewModel
            {
                Borrower = new Borrower()
            };
            return View("BorrowerForm", borrowerFormViewModel);
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Edit(int id)
        {
            var borrower = _db.Borrowers.SingleOrDefault(b => b.Id == id);
            if (borrower == null)
            {
                return HttpNotFound();
            }

            var borrowerFormViewModel = new BorrowerFormViewModel
            {
                Borrower = borrower
            };
            return View("BorrowerForm", borrowerFormViewModel);
        }

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPost]
        public ActionResult Save(Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                var borrowerFormViewModel = new BorrowerFormViewModel
                {
                    Borrower = new Borrower()
                };
                return View("BorrowerForm", borrowerFormViewModel);
            }

            if (borrower.Id==0)
            {
                _db.Borrowers.Add(borrower);
            }
            else //borrower.Id != 0
            {
                var borrowerInDb = _db.Borrowers.Single(b => b.Id == borrower.Id);
                borrowerInDb.Name = borrower.Name;
                borrowerInDb.Surname = borrower.Surname;
                borrowerInDb.NationalId = borrower.NationalId;
                borrowerInDb.BirthDate = borrower.BirthDate;
                borrowerInDb.Address = borrower.Address;
                borrowerInDb.Phone = borrower.Phone;
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Borrowers");
        }

        [Authorize(Roles = RoleName.CanManage)]
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            var borrowerInDb = _db.Borrowers.Single(b => b.Id == id);
            if (borrowerInDb == null)
            {
                HttpNotFound();
            }
            else
            {
                _db.Borrowers.Remove(borrowerInDb);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Borrowers");
        }
    }
}