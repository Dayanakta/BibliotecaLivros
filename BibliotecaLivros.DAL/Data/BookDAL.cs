using BibliotecaLivros.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;

namespace BibliotecaLivros.DAL.Data
{
    public class BookDAL
    {
        #region Sqls 
        readonly string sqlBooksInsert = @"insert into books (Id,Title,Subtitle,Description,ImageLinks) values ($Id,$Title,$Subtitle,$Description,$ImageLinks)";
        readonly string sqlBooksDelete = @"delete from books where id = $Id";
        readonly string sqlBooksSelectAll = @"select Id,Title,Subtitle,Description,ImageLinks from books";
        readonly string sqlBooksSelectOne = @"select Id,Title,Subtitle,Description,ImageLinks from books where Id = $Id";

        #endregion

        private IList books;

        public BookDAL()
        {

        }

        public bool Insert(Book book)
        {
            bool success = false;
            try
            {
                SQLiteParameter[] parameters = new SQLiteParameter[] {
                    new SQLiteParameter("$Id", book.ID),
                    new SQLiteParameter("$Title", book.Title),
                    new SQLiteParameter("$Subtitle", book.Subtitle),
                    new SQLiteParameter("$Description", book.Description),
                    new SQLiteParameter("$ImageLinks", book.ImageLinks)
                };
                DbHelper.ExecuteNonQueryCommand(sqlBooksInsert, parameters);
                success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return success;
        }

        public List<Book> GetAll()
        {
            try
            {
                DbHelper.ExecuteSelectCommand(sqlBooksSelectAll, null, FillBookList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }

            return books as List<Book>;
        }

        public Book Get(string id)
        {
            List<Book> booksConverted = new List<Book>();
            try
            {
                SQLiteParameter[] parameters = new SQLiteParameter[] {
                    new SQLiteParameter("$Id", id)
                };
                DbHelper.ExecuteSelectCommand(sqlBooksSelectOne, parameters, FillBookList);
                booksConverted = books as List<Book>;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }

            return booksConverted.Count > 0 ? booksConverted[0] : null;
        }

        public bool Delete(string id)
        {
            bool success = false;
            try
            {
                SQLiteParameter[] parameters = new SQLiteParameter[] {
                    new SQLiteParameter("$Id", id)
                };
                success = DbHelper.ExecuteNonQueryCommand(sqlBooksDelete, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }

            return success;
        }

        private void FillBookList(SQLiteDataReader rdrSelect)
        {
            Book book;
            books = new List<Book>();
            while (rdrSelect.Read())
            {
                book = new Book();
                if (!(rdrSelect[0] is DBNull))
                {
                    book.ID = rdrSelect.GetString(0);
                }
                if (!(rdrSelect[1] is DBNull))
                {
                    book.Title = rdrSelect.GetString(1);
                }
                if (!(rdrSelect[2] is DBNull))
                {
                    book.Subtitle = rdrSelect.GetString(2);
                }
                if (!(rdrSelect[3] is DBNull))
                {
                    book.Description = rdrSelect.GetString(3);
                }
                if (!(rdrSelect[4] is DBNull))
                {
                    book.ImageLinks = rdrSelect.GetString(4);
                }
                books.Add(book);
            }
        }
    }
}

