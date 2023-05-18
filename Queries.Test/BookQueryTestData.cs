using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Test
{
    public class BookQueryTestData
    {

        public static IEnumerable<Autor> GetAuthors()
        {
            yield return new Autor { Nombre = "Autor 1", Apellidos = "Apellido 1" };
            yield return new Autor { Nombre = "Autor 2", Apellidos = "Apellido 2" };
            yield return new Autor { Nombre = "Autor 3", Apellidos = "Apellido 3" };
            yield return new Autor { Nombre = "Autor 4", Apellidos = "Apellido 4" };
            yield return new Autor { Nombre = "Autor 5", Apellidos = "Apellido 5" };            
        }

        public static IEnumerable<Libro> GetBooks()
        {
            yield return new Libro { EditorialId = 1, Titulo = "Libro 1", Sinopsis = "A test book1", NPaginas = "100", Autores = GetAuthors().ToList() };
            yield return new Libro { EditorialId = 1, Titulo = "Libro 2", Sinopsis = "A test book2", NPaginas = "200", Autores = GetAuthors().TakeLast(2).ToList() };
            yield return new Libro { EditorialId = 2, Titulo = "Libro 3", Sinopsis = "A test book3", NPaginas = "300", Autores = GetAuthors().Skip(1).Take(1).ToList() };
            yield return new Libro { EditorialId = 3, Titulo = "Libro 4", Sinopsis = "A test book4", NPaginas = "400", Autores = GetAuthors().TakeLast(1).ToList() };
        }

    }
}
