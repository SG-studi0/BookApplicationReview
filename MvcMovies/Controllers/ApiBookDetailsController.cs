using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MvcMovies.Models;

namespace MvcMovies.Controllers
{
    public class ApiBookDetailsController : ApiController
    {
        private MvcMoviesdbContext db = new MvcMoviesdbContext();

        // GET: api/ApiBookDetails
        public IQueryable<BookDetail> GetBookDetails()
        {
            return db.BookDetails;
        }

        // GET: api/ApiBookDetails/5
        [ResponseType(typeof(BookDetail))]
        public IHttpActionResult GetBookDetail(int id)
        {
            BookDetail bookDetail = db.BookDetails.Find(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            return Ok(bookDetail);
        }

        // PUT: api/ApiBookDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookDetail(int id, BookDetail bookDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookDetail.id)
            {
                return BadRequest();
            }

            db.Entry(bookDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiBookDetails
        [ResponseType(typeof(BookDetail))]
        public IHttpActionResult PostBookDetail(BookDetail bookDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookDetails.Add(bookDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookDetail.id }, bookDetail);
        }

        // DELETE: api/ApiBookDetails/5
        [ResponseType(typeof(BookDetail))]
        public IHttpActionResult DeleteBookDetail(int id)
        {
            BookDetail bookDetail = db.BookDetails.Find(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            db.BookDetails.Remove(bookDetail);
            db.SaveChanges();

            return Ok(bookDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookDetailExists(int id)
        {
            return db.BookDetails.Count(e => e.id == id) > 0;
        }
    }
}