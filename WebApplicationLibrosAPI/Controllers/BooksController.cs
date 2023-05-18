using Microsoft.AspNetCore.Mvc;
using Models;
using Queries;

namespace WebApplicationLibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGetBookList bookListQuery;
        private readonly ICreateBook createBookQuery;

        public BooksController(IGetBookList bookListQuery, ICreateBook createBookQuery)
        {
            this.bookListQuery = bookListQuery;
            this.createBookQuery = createBookQuery;
        }

        /// <summary>
        /// Retrieves the data from books, publishing house, and authors
        /// </summary>
        /// <returns>A list of Libro representing the data</returns>
        [HttpGet("v1/GetBookList")]
        public async Task<IEnumerable<Libro>> GetBookList()
        {
            return await bookListQuery.Handle();
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="bookData">The new book data</param>
        /// <returns>An integer with representing the new book id</returns>
        [HttpPost("v1/CreateBook")]
        public async Task<int> CreateBook([FromBody] Libro bookData)
        {
            return await createBookQuery.Handle(bookData);
        }
    }
}
