using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovies.Models;

namespace MvcMovies.Controllers
{
    public class RegisterUsersController : Controller
    {

        RegisterUsersDataAccessLayer dataaccesslayer = new RegisterUsersDataAccessLayer();
        // GET: RegisterUsers
  
        public ActionResult Index()
        {

            List<RegisterUsersModel> listRegisterUsers = new List<RegisterUsersModel>();
            listRegisterUsers = dataaccesslayer.ViewAllRegisterUsers().ToList();

            return View(listRegisterUsers);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //only authorized access use [Authorize()] 
        //[Authorize()]
        [HttpPost]

        public ActionResult Create([Bind] RegisterUsersModel RegisterUsersModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string x = dataaccesslayer.RegisterUsers(RegisterUsersModel);
                    TempData["msg"] = x;
                   return RedirectToAction("Create", "RegisterUsers");
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }



        






    
        // POST: RegisterUsersController2/Delete/5
        [HttpGet]
        
        public ActionResult Details(int id )
        {


            RegisterUsersModel xy = new RegisterUsersModel();
            try
            {
                // TODO: Add delete logic here

              xy =  dataaccesslayer.GetRegisterUsers(id);


                return RedirectToAction("Index", "Home");
            }
            catch
            {

            }
            return View(xy);
        }



    }

}

    



