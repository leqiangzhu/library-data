using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.Models;
using System;

namespace Library.Controllers
{
    public class BookController : Controller
    {
      [HttpGet("book")]
         public ActionResult Index()
         {
               List<Book> allBooks = Book.GetAll();
               return View(allBooks);
         }

         [HttpPost("/book")]
      public ActionResult Create()
      {

      Book newBook = new Book (Request.Form["bookName"],
      Int32.Parse(Request.Form["authorId"]),Int32.Parse(Request.Form["bookCopies"]));
      newBook.Save();
      List<Book> allBooks = Book.GetAll();
      //return RedirectToAction("Index");
      return View("Index", allBooks);
      }

        // this is a method to search book by id,
       [HttpGet("book/Search")]
      public ActionResult SearchById()
      {
        Book foundBook=Book.FindById(Int32.Parse(Request.Form["bookSearchId"]));
        List<Book> foundBooks = Book.GetAll();
        foundBooks.Add(foundBook);
        return View(foundBooks);
      }


    }
}
