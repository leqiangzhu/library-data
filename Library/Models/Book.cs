using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Library;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Library.Models
{
  public  class Book
  {
    private  string _bookName { get; set; }
    private  int _bookId{ get; set; }
    private  int _authorId { get; set; }
    private  int _bookCopies{ get; set; }

    public  Book(string bookName,int authorId, int bookCopies,int bookId=0){
        _bookName=bookName;
        _bookId=bookId;
        _authorId=authorId;
        _bookCopies=bookCopies;

    }

    public override bool Equals(System.Object otherBook)
    {
        if(!(otherBook is Book))
        {
            return false;
        }
        else
        {
            Book newBook = (Book) otherBook;
            bool areNamesEqual = this._bookName.Equals(newBook._bookName);
            bool areIdsEqual = this._bookId.Equals(newBook._bookId);
            bool areAuthorEqual = this._authorId.Equals(newBook._authorId);
            bool areCopiesEqual = this._bookCopies.Equals(newBook._bookCopies);
            return (areNamesEqual && areIdsEqual && areCopiesEqual && areAuthorEqual);
        }
    }

    public override int GetHashCode()
    {
        return this._bookName.GetHashCode();
    }


    public  static  List<Book> GetAll(){
      List<Book> allBooks = new List<Book> {};
      MySqlConnection conn =DB.Connection();
      conn.Open();
      var cmd =conn.CreateCommand() as MySqlCommand;
      cmd.CommandText=@"SELECT * FROM books;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
           {
               int bookId = rdr.GetInt32(0);
               string bookName = rdr.GetString(1);
               int authorId=rdr.GetInt32(4);
               int bookCopies=rdr.GetInt32(2);
               Book newBook = new Book(bookName, authorId,bookCopies,bookId);
               allBooks.Add(newBook);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return allBooks;
    }


    public void Save()
       {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO books (book_name,author_id,book_copies) VALUES (@bookName,@authorId,@bookCopies,);";

          //  MySqlParameter stylistName1 = new MySqlParameter();
          //  stylistName1.ParameterName = "@bookName";
          //  stylistName1.Value = this.GetStylistName();
          //  cmd.Parameters.Add(stylistName1);

           cmd.Parameters.Add(new MySqlParameter("@bookName", _bookName));
           cmd.Parameters.Add(new MySqlParameter("@authorId", _authorId));
           cmd.Parameters.Add(new MySqlParameter("@bookCopies", _bookCopies));
           cmd.ExecuteNonQuery();
           _bookId = (int)cmd.LastInsertedId;
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
       }


      public  static  Book FindById(int id){
        MySqlConnection conn=DB.Connection();
        conn.Open();
        var cmd =conn.CreateCommand() as MySqlCommand;
        cmd.CommandText=@"SELECT * FROM books WHERE book_id =@SearchId;";

        cmd.Parameters.Add(new MySqlParameter("@SearchId", id));
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int bookId=0;
        string bookName="";
        int authorId=0;
        int bookCopies=0;

        while (rdr.Read())
        {

           bookId = rdr.GetInt32(0);
           bookName = rdr.GetString(1);
           authorId=rdr.GetInt32(4);
           bookCopies=rdr.GetInt32(2);

        }
          Book foundBook = new Book(bookName, authorId,bookCopies,bookId);


        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }

        return foundBook;

      }

        public  static  Book FindByString(string str){
        MySqlConnection conn=DB.Connection();
        conn.Open();
        var cmd =conn.CreateCommand() as MySqlCommand;
          // search sql by char
        cmd.CommandText=@"SELECT * FROM books WHERE book_name = @SearchStr;";

        cmd.Parameters.Add(new MySqlParameter("@SearchStr", str));
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int bookId=0;
        string bookName="";
        int authorId=0;
        int bookCopies=0;

        while (rdr.Read())
        {
          bookId = rdr.GetInt32(0);
          bookName = rdr.GetString(1);
          authorId=rdr.GetInt32(4);
          bookCopies=rdr.GetInt32(2);

        }
          Book foundBook = new Book(bookName, authorId,bookCopies,bookId);


        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }

        return foundBook;

      }






  }



}
