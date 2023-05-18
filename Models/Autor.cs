namespace Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
