using BibliotecaLivros.DAL.Data;
using BibliotecaLivros.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace BibliotecaLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public IEnumerable<Volume> Volumes { get; private set; }

        public Book Book { get; private set; }
            
        public List<Book> Books { get; private set; }

        public BookController()
        {
        }

        #region Get
        [HttpGet]
        public async Task<List<Book>> Get(string search)
        {
            try
            {
                Books = new List<Book>();
                var bookDAL = new BookDAL();
                HttpClient client = new HttpClient();
                string urlBase = "https://www.googleapis.com/books/v1/volumes?q=";
                string keyIntegracao = "&key=AIzaSyACytjGx2Ijj8uaJz9FBWMF1Vl97Xn6tpU";
                string urlIntegracao = String.Concat(urlBase + search + keyIntegracao);
                var request = new HttpRequestMessage(HttpMethod.Get, urlIntegracao);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Volumes = JObject.Parse(responseContent)["items"].ToObject<IEnumerable<Volume>>();
                    foreach (var volume in Volumes)
                    {
                        Book = new Book
                        {
                            ID = volume.ID,
                            Title = volume.VolumeInfo.Title,
                            Subtitle = volume.VolumeInfo.Subtitle,
                            Description = volume.VolumeInfo.Description
                        };

                        if (volume.VolumeInfo.ImageLinks != null)
                        {
                            if (!string.IsNullOrEmpty(volume.VolumeInfo.ImageLinks.Thumbnail))
                            {
                                Book.ImageLinks = volume.VolumeInfo.ImageLinks.Thumbnail;
                            }
                        }
                        if (bookDAL.Get(Book.ID) == null)
                        {
                            Books.Add(Book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
            return Books;

        }
        #endregion


    }

}
