using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Queries
{
    /// <summary>
    /// Class that retrieves the list of books with their publishing house and authors
    /// </summary>
    public class GetBookList : IGetBookList
    {
        private readonly LibrosInventoryContext queryDbAccessor;

        public GetBookList(LibrosInventoryContext queryDbAccessor)
        {
            this.queryDbAccessor = queryDbAccessor;
        }

        /// <summary>
        /// Method that handles the book list query
        /// </summary>
        /// <returns>A list of Libro</returns>
        public async Task<IEnumerable<Libro>> Handle()
        {
            var libros = await queryDbAccessor.Libros.Include(l => l.Editorial).Include(l => l.Autores).ToListAsync();
            return libros;
        }
    }
}
