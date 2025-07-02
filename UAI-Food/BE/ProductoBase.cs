
namespace BE
{
    public abstract class ProductoBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double Precio { get; set; }
        public bool esAgregado { get; set; }
        protected ProductoBase() { }
        protected ProductoBase(int id, string nombre, string descripcion, double precio, bool EsAgregado)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            esAgregado = EsAgregado;
        }
    }
}
