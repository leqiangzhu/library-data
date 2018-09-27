using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Library;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Library.Models
{
  public  class Patron
  {
    public  string _patronName { get; set; }
    public  int _patronId  { get; set; }
  //  private  int _authorId={set;get};
  //  private  int _copiesNumber={set;get};
    public int _availableNum=5;

    public  Patron(string patronName,int patronId=0){
        _patronName=patronName;
        _patronId=patronId;
    }

    public override bool Equals(System.Object otherPatron)
    {
        if(!(otherPatron is Patron))
        {
            return false;
        }
        else
        {
            Patron newPatron = (Patron) otherPatron;
            bool areNamesEqual = this._patronName.Equals(newPatron._patronName);
            bool areIdsEqual = this._patronId.Equals(newPatron._patronId);
          //  bool areAuthorEqual = this._authorId.Equals(newPatron._authorId);
            return (areNamesEqual && areIdsEqual);
        }
    }

    public override int GetHashCode()
    {
        return this._patronName.GetHashCode();
    }


    public  static  List<Patron> GetAll(){
      List<Patron> allPatrons=new List<Patron>{};
      MySqlConnection conn =DB.Connection();
      conn.Open();
      var cmd =conn.CreateCommand() as MySqlCommand;
      cmd.CommandText=@"SELECT * FROM patrons;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
           {
               int patronId = rdr.GetInt32(0);
               string patronName = rdr.GetString(1);
               Patron newPatron = new Patron(patronName, patronId);
               allPatrons.Add(newPatron);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return allPatrons;
    }


    public void Save()
       {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO patrons (patron_name) VALUES (@patronName);";

          //  MySqlParameter stylistName1 = new MySqlParameter();
          //  stylistName1.ParameterName = "@patronName";
          //  stylistName1.Value = this.GetStylistName();
          //  cmd.Parameters.Add(stylistName1);

           cmd.Parameters.Add(new MySqlParameter("@patronName", _patronName));
           cmd.ExecuteNonQuery();
           _patronId = (int)cmd.LastInsertedId;
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
       }


      public  static  Patron FindById(int id){
        MySqlConnection conn=DB.Connection();
        conn.Open();
        var cmd =conn.CreateCommand() as MySqlCommand;
        cmd.CommandText=@"SELECT * FROM patrons WHERE patron_id =@SearchId;";

        cmd.Parameters.Add(new MySqlParameter("@SearchId", id));
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int patronId = 0;
        string patronName = "";
        while (rdr.Read())
        {
            patronId = rdr.GetInt32(0);
            patronName = rdr.GetString(1);
        }
        Patron foundPatron = new Patron(patronName, patronId);

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    
        return foundPatron;

      }

        public  static  Patron FindByString(string str){
        MySqlConnection conn=DB.Connection();
        conn.Open();
        var cmd =conn.CreateCommand() as MySqlCommand;
          // search sql by char
        cmd.CommandText=@"SELECT * FROM patrons WHERE patron_name = @SearchStr;";

        cmd.Parameters.Add(new MySqlParameter("@SearchStr", str));
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int patronId = 0;
        string patronName = "";
        while (rdr.Read())
        {
            patronId = rdr.GetInt32(0);
            patronName = rdr.GetString(1);
        }
        Patron foundPatron = new Patron(patronName, patronId);

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }

        return foundPatron;

      }






  }



}
