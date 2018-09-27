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

        //   [HttpPost("/patron/{patronId}")]
        // public ActionResult CreateBook(int patronId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Patron selectpatron = Patron.FindById(patronId);
        //     Book newBook= new Book( Request.Form["BookName"],patronId);
        //     newBook.Save();
        //     List<Book> patronBook = selectpatron.GetBooks();
        //     // model.Add("patron", selectpatron);
        //     // model.Add("Book", Request.Form["BookName"]);
        //      model.Add("patron", selectpatron);
        //      model.Add("Book", patronBook);
        //     return View("Details", model);
        // }





    }
}
