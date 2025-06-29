namespace BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public Usuario(int Id, string Nombre)
        {
            Id = Id;
            Nombre = Nombre;
        }
    }
}
