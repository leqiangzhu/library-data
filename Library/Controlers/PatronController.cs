using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.Models;
using System;

namespace Library.Controllers
{
    public class PatronController : Controller
    {
      [HttpGet("patron")]
         public ActionResult Index()
         {
               List<Patron> allPatrons = Patron.GetAll();
               return View(allPatrons);
         }

          [HttpGet("/Patron/{patronId}")]
        public ActionResult CreateBook(int patronId)
        { 
            Patron selectpatron = Patron.FindById(patronId);
            return View("Details", selectpatron);
        }


           [HttpPost("/Patron/{patronId}")]
        public ActionResult CreateBook(int patronId)
        { 
            Patron selectpatron = Patron.FindById(patronId);
            return View("Details", selectpatron);
        }



     
    }
}
