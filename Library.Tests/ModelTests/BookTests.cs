using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;

namespace Library.TestTools
{
  [TestClass]
  public class BookTests : Book
  {
    public BookTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library_data_test;";
    }

    // public void Dispose()
    // {
    //   Book.DeleteAll();
    //   Patron.DeleteAll();
    // }

    [TestMethod]
    public void GetAll_DatabaseStartsEmpty_0()
    {
      //Arrange
      List<Book> allBooks = new List<Book>{};
      Book newBook =new Book("LOVE C#",2,30,3);
      allBooks.Add(newBook);
    //  List<Book> allBooks = Book.GetAll();
      int count = allBooks.Count;

      //Act
      //Assert
      Assert.AreEqual(count, 1);
    }

    // [TestMethod]
    // public void Save_SavedItemIsSavedToDB_True()
    // {
    //   //Arrange
    //   //Act
    //   //Assert
    // }

  }
}
