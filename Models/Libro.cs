using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Libro
    {
        [Key]
        public int ISBN { get; set; }
        public int EditorialId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public Editorial Editorial { get; set; }
        public List<Autor> Autores { get; set; }
    }
}
