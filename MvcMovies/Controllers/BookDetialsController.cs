using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

// add 
using MvcMovies.Models;




namespace MvcMovies.Controllers
{
    public class BookDetialsController : Controller
    {

        // add link to data access layer 

        BookDetailsDataAccessLayer BookDetialsDataAccessLayer = new BookDetailsDataAccessLayer();

        // GET: BookDetials

       // [Authorize()]
        public ActionResult Index()


        {

            List<BookDetailsModel> listBookDetials = new List<BookDetailsModel>();

            listBookDetials = BookDetialsDataAccessLayer.ViewAllBookDetials().ToList();

            return View(listBookDetials);
        }

        // GET: BookDetials/Details/5

       [HttpGet]
        public ActionResult Details(int id)


        {
            //  if (id == null)
            //{
            //  return HttpNotFound();
            //}

          
            BookDetailsModel  bookDetailsmodel = BookDetialsDataAccessLayer.GetBookDetials(id);

            if (bookDetailsmodel == null)
            {
                return HttpNotFound();
            }


            return View(bookDetailsmodel);


        }

        // GET: BookDetials/Create

       

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookDetials/Create
        [HttpPost]
        public ActionResult Create([Bind] BookDetailsModel BookDetailsModel )
        {
            try
            {
                // TODO: Add insert logic here

                // CreateBookDetails from data acces layer 
                // add modelstate

                if (ModelState.IsValid)
                {

                    String x = BookDetialsDataAccessLayer.CreateBookDetials(BookDetailsModel);
                    TempData["msg"] = x;
                    return RedirectToAction("Index", "Home");
                }
              
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        // GET: BookDetials/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {

            BookDetailsModel BookDetailsModel = BookDetialsDataAccessLayer.GetBookDetials(id);
            return View(BookDetailsModel);
        }

        // POST: BookDetials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] BookDetailsModel BookDetailsModel )
        {
           
                // TODO: Add update logic here

          

                if (ModelState.IsValid)
                {

                  BookDetialsDataAccessLayer.UpdateBookdetials(BookDetailsModel);
                  return RedirectToAction("Index", "BookDetials");
                }
         
            return View(BookDetailsModel);
        }

        // GET: BookDetials/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookDetailsModel BookDetailsModel = BookDetialsDataAccessLayer.GetBookDetials(id);
            return View(BookDetailsModel);
           
        }

        // POST: BookDetials/Delete/5
      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                // TODO: Add delete logic here

                BookDetialsDataAccessLayer.DeleteBookDetails(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
