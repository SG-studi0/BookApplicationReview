using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// need to add 

using System.Data.Entity;


namespace MvcMovies.Models
{
    public class BookDetailsModel
    {
       
        public int id { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string Rating { get; set; }
    }

   
}