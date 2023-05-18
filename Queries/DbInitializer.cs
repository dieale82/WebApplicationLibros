using DatabaseContext;
using Models;

namespace Queries
{
    /// <summary>
    /// Class created for populating the database with test data
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(LibrosInventoryContext context)
        {
            #region Editoriales
            if (context.Editoriales.Any())
            {
                return;
            }

            var editors = new Editorial[]
            {
                new Editorial { Nombre = "Book 1", Sede = "Branch 1" },
                new Editorial { Nombre = "Book 2", Sede = "Branch 2" },
                new Editorial { Nombre = "Book 3", Sede = "Branch 3" }
            };

            context.Editoriales.AddRange(editors);
            #endregion

            #region Authors
            if (context.Autores.Any())
            {
                return;
            }

            var authors = new Autor[]
            {
                new Autor { Nombre = "Autor 1", Apellidos = "Apellido 1" },
                new Autor { Nombre = "Autor 2", Apellidos = "Apellido 2" },
                new Autor { Nombre = "Autor 3", Apellidos = "Apellido 3" }
            };
            context.Autores.AddRange(authors);

            #endregion

            #region Books
            if (context.Libros.Any())
            {
                return;
            }

            var books = new Libro[]
            {
                new Libro { EditorialId = 1, Titulo = "Libro 1", Sinopsis = "A test book1", NPaginas = "100", Autores = authors.ToList() },
                new Libro { EditorialId = 1, Titulo = "Libro 2", Sinopsis = "A test book2", NPaginas = "200", Autores = new List<Autor>{ authors[0] } },
                new Libro { EditorialId = 2, Titulo = "Libro 3", Sinopsis = "A test book3", NPaginas = "300", Autores = new List<Autor>{ authors[1] } },
                new Libro { EditorialId = 3, Titulo = "Libro 4", Sinopsis = "A test book4", NPaginas = "400", Autores = new List<Autor>{ authors[2] } }
            };
            context.Libros.AddRange(books);

            #endregion

            context.SaveChanges();
        }
    }
}
