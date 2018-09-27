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
      //  [HttpPost("book/Search")]
      // public ActionResult Search()
      // {
      //   int SearchId=Int32.Parse(Request.Form["bookSearchId"]);
      //   Book foundBook=Book.FindById(SearchId);
      //   List<Book> foundBooks = Book.GetAll();
      //   foundBooks.Add(foundBook);
      //   return View("Search",foundBooks);
      // }

      //TEST Search

    //   [HttpPost("/search")]
    //  public ActionResult Search(int bookId)
    //  {
    //    int SearchId=Int32.Parse(Request.Form["bookSearchId"]);
    //    Book foundBook=Book.FindById(SearchId);
    //    List<Book> foundBooks = Book.GetAll();
    //    foundBooks.Add(foundBook);
    //    return View("search",foundBooks);
    //  }

      [HttpGet("/search")]
     public ActionResult Search(int bookId)
     {
       //int SearchId=Int32.Parse(Request.Form["bookSearchId"]);
       Book foundBook=Book.FindById(SearchId);
      List<Book> foundBooks = Book.GetAll();
      foundBooks.Add(foundBook);
       return View(foundBooks);
     }



    //   [HttpGet("/Search")]
    //  public ActionResult Search()
    //  {
    //   //  int SearchId=Int32.Parse(Request.Form["bookSearchId"]);
    //   //  Book foundBook=Book.FindById(SearchId);
    //   //  List<Book> foundBooks = Book.GetAll();
    //   //  foundBooks.Add(foundBook);
    //    return View();
    //  }


    }
}
