namespace Models
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
