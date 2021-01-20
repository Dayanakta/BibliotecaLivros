using BibliotecaLivros.API.Controllers;
using BibliotecaLivros.DAL.Data;
using BibliotecaLivros.Domain.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BibliotecaLivros.Test
{
    public class BookTest
    {
        public readonly HttpClient client;
        [Fact(DisplayName = "ValidationObjectVolume")]
        public void ValidationObjectVolume()
        {
            string kind = "books#volume";
            string id = "zaRoX10_UsMC";
            string etag = "pm1sLMgKfMA";
            string selflink = "https://www.googleapis.com/books/v1/volumes/zaRoX10_UsMC";

            var book = new Volume
            {
                Kind = kind,
                ID = id,
                Etag = etag,
                SelfLink = selflink
            };

            Assert.Equal(kind, book.Kind);
            Assert.Equal(id, book.ID);
            Assert.Equal(etag, book.Etag);
            Assert.Equal(selflink, book.SelfLink);

        }

        [Fact(DisplayName = "CreateDatabase")]
        public void CreateDatabase()
        {
            bool success = DbHelper.CreateDataBase();
            Assert.True(success);
        }

        [Fact(DisplayName = "GetAsync")]
        public async Task GetAsync()
        {
            IEnumerable<Book> expect;
            string search = "Flores";
            var service = new BookController();
            expect = await service.Get(search);
            Assert.NotNull(expect);
        }

        [Fact(DisplayName = "GetDados")]
        public void GetDados()
        {
            var bookDAL = new BookDAL();
            List<Book> books = bookDAL.GetAll();
            Assert.NotEmpty(books);
        }

        [Fact(DisplayName = "PostBooks")]
        public async Task PostBooks()
        {
            var bookDAL = new BookDAL();
            bool successSelect;
            string search = "Cadeias produtivas de flores e mel";
            var service = new BookController();
            bookDAL.Delete("eBAVuw7ob14C");
            var books = await service.Get(search);
            successSelect = bookDAL.Insert(books[0]);
            Assert.True(successSelect);
        }

        [Fact(DisplayName = "DeleteBook")]
        public void DeleteBook()
        {
            var bookDAL = new BookDAL();
            bool success;
            string idBook = "eBAVuw7ob14C000";
            success = bookDAL.Delete(idBook);
            Assert.False(success);
        }
    }
}

