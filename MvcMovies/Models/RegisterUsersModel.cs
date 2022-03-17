using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


using System.Data.Entity;

namespace MvcMovies.Models
{
    public class RegisterUsersModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string password { get; set; }



    }

    public class LoginRegisterUsersModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }


    public class MvcMoviesdbContext : DbContext
    {
        public DbSet<RegisterUsersModel> RegisterUserModel { get; set; }
        public DbSet<BookDetailsModel> BookDetialsModel { get; set; }

        public System.Data.Entity.DbSet<MvcMovies.Models.BookDetail> BookDetails { get; set; }

        // USED IN CODE FIRST , ENTITY FRAMEWORK 
    }
}