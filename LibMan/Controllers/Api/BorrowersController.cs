using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibMan.Models.Api
{
    public class BorrowersController : ApiController
    {
        private readonly ApplicationDbContext _db;

        public BorrowersController()
        {
            _db = new ApplicationDbContext();
        }

        //Get /api/borrowers
        public IEnumerable<Borrower> GetBorrowers()
        {
            return _db.Borrowers.ToList();
        }


        //GET /api/borrowers/1
        public IHttpActionResult GetBorrowers(int id)
        {
            var borrower = _db.Borrowers.SingleOrDefault(b => b.Id == id);
            if (borrower == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(borrower);
        }

        //POST /api/borrowers
        [HttpPost]
        public IHttpActionResult CreateBorrower(Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _db.Borrowers.Add(borrower);
            _db.SaveChanges();
            return Ok(borrower);
        }

        //PUT /api/borrowers/1
        [HttpPut]
        public IHttpActionResult UpdateBorrowe(int id, Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var borrowerInDb = _db.Borrowers.SingleOrDefault(b => b.Id == id);
            if (borrowerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            borrowerInDb.Name = borrower.Name;
            borrowerInDb.Surname = borrower.Surname;
            borrowerInDb.NationalId = borrower.NationalId;
            borrowerInDb.BirthDate = borrower.BirthDate;
            borrowerInDb.Address = borrower.Address;
            borrowerInDb.Phone = borrower.Phone;
            _db.SaveChanges();
            return Ok(borrowerInDb);
        }



        //DELETE /api/borrowers/1
        [HttpDelete]
        public IHttpActionResult DeleteBorrower(int id)
        {
            var borrowerInDb = _db.Borrowers.SingleOrDefault(b => b.Id == id);
            if (borrowerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _db.Borrowers.Remove(borrowerInDb);
            _db.SaveChanges();
            return Ok();

        }
    }
}

