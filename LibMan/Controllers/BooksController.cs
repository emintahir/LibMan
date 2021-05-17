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
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }


        // GET: Book
        public ActionResult Index()
        {
            var books = _db.Books.Include(b => b.Category).ToList();
            if (User.IsInRole(RoleName.CanManage))
            {
                return View("Index",books);
            }
            
            return View("IndexRO",books);
        }

        public ActionResult Details(int id)
        {
            var book = _db.Books.Include(b => b.Category).SingleOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult New()
        {
            var bookFormViewModel = new BookFormViewModel
            {
                Book = new Book(),
                Categories = _db.Categories.ToList()
            };
            return View("BookForm", bookFormViewModel);
        }


        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Edit(int id)
        {
            var book = _db.Books.Include(b => b.Category).SingleOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var bookFormViewModel = new BookFormViewModel
            {
                Book = book,
                Categories = _db.Categories.ToList()
            };
            return View("BookForm", bookFormViewModel);
        }

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var bookFormViewModel = new BookFormViewModel
                {
                    Book = new Book(),
                    Categories = _db.Categories.ToList()
                };
                return View("BookForm", bookFormViewModel);
            }

            if (book.BookId == 0)
            {
                book.DateAddedToLibrary = DateTime.Today;
                _db.Books.Add(book);
            }
            else //book.Id != 0
            {
                var bookInDb = _db.Books.Single(b => b.BookId == book.BookId);
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.Publisher = book.Publisher;
                bookInDb.ImageAddress = book.ImageAddress;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.YearPublished = book.YearPublished;
                bookInDb.Page = book.Page;
                bookInDb.CategoryId = book.CategoryId;
        
           
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        [Authorize(Roles = RoleName.CanManage)]
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            var bookInDb = _db.Books.Single(b => b.BookId == id);
            if (bookInDb == null)
            {
                HttpNotFound();
            }
            else
            {
                _db.Books.Remove(bookInDb);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}