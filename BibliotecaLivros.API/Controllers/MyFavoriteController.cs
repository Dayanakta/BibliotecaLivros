using BibliotecaLivros.DAL.Data;
using BibliotecaLivros.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BibliotecaLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyFavoriteController : ControllerBase
    {
        public List<Book> Books { get; private set; }

        #region Get
        [HttpGet]
        public List<Book> Get()
        {
            try
            {
                BookDAL bookDAL = new BookDAL();
                Books = bookDAL.GetAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return Books;

        }
        #endregion
        #region Delete
        [HttpDelete]
        public IEnumerable<Book> Delete(string bookId)
        {
            try
            {
                BookDAL bookDAL = new BookDAL();
                bookDAL.Delete(bookId);
                Books = bookDAL.GetAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return Books;

        }
        #endregion


        #region Post
        [HttpPost]
        public Book Post(Book book)
        {
            try
            {
                var bookDAL = new BookDAL();
                bool successSelect;
                successSelect = bookDAL.Insert(book);
                if (!successSelect)
                {
                    book = new Book();
                    throw new Exception("Não foi possivél adicionar o livro ao 'Meus Favoritos'.");

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return book;

        }
        #endregion
    }
}








