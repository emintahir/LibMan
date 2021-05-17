using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibMan.Models;

namespace LibMan.Controllers.Api
{
    public class BooksController : ApiController
    {
        private readonly ApplicationDbContext _db;

        public BooksController()
        {
            _db = new ApplicationDbContext();
        }
        //Get /api/books
        public IEnumerable<Book> GetBooks()
        {
            return _db.Books.ToList();
        }


        //GET /api/books/1
        public IHttpActionResult GetBooks(int id)
        {
            var book = _db.Books.SingleOrDefault(b => b.BookId == id);
            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(book);
        }

        //POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(book);
        }

        //PUT /api/books/1
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var bookInDb = _db.Books.SingleOrDefault(b => b.BookId == id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            bookInDb.Title = book.Title;
            bookInDb.Author = book.Author;
            bookInDb.Publisher = book.Publisher;
            bookInDb.ImageAddress = book.ImageAddress;
            bookInDb.NumberInStock = book.NumberInStock;
            bookInDb.YearPublished = book.YearPublished;
            bookInDb.Page = book.Page;
            bookInDb.CategoryId = book.CategoryId;
            _db.SaveChanges();
            return Ok(bookInDb);
        }



        //DELETE /api/books/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _db.Books.SingleOrDefault(b => b.BookId == id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _db.Books.Remove(bookInDb);
            _db.SaveChanges();
            return Ok();

        }

    }
}
