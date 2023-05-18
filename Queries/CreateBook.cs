using DatabaseContext;
using Models;

namespace Queries
{
    /// <summary>
    /// Class that creates a book, with its publishing house and authors
    /// </summary>
    public class CreateBook : ICreateBook
    {
        private readonly LibrosInventoryContext queryDbAccessor;

        public CreateBook(LibrosInventoryContext queryDbAccessor)
        {
            this.queryDbAccessor = queryDbAccessor;
        }

        /// <summary>
        /// Method that handles the book creation task
        /// </summary>
        /// <param name="bookData">The new book's data</param>
        /// <returns>An intenger representing the added book id</returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> Handle(Libro bookData)
        {
            try
            {
                if(bookData == null)
                    throw new ArgumentNullException("Data is empty");

                queryDbAccessor.Libros.Add(bookData);
                await queryDbAccessor.SaveChangesAsync();

                return bookData.ISBN;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
