using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace WebApplicationLibros.Controllers
{
    public class BookController : Controller
    {
        public IConfiguration Configuration { get; }
        public BookController(IConfiguration configuration) {
            this.Configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var apiBaseUrl = this.Configuration.GetValue<string>("WebAPIBaseUrl");
            var myApiKey = this.Configuration.GetValue<string>("MyApiKey");
            string responseData = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("MyApiKey", myApiKey);

                string endpoint = apiBaseUrl + "GetBookList";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        responseData = await response.Content.ReadAsStringAsync();
                    }                    
                }
            }

            List<Libro>? bookListData = JsonConvert.DeserializeObject<List<Libro>>(responseData);

            ViewBag.BooksDataList = bookListData;

            return View();
        }
    }
}
