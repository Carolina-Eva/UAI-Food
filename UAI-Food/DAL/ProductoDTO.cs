using BE;

namespace DAL
{
    public class ProductoDTO : ProductoBase
    {
        public int Id { get; set; }
        public override string Nombre { get; set; }
        public override double Precio { get; set; }
        public override bool esAgregado { get; set; }

        public ProductoDTO() : base()
        {

        }
    }
}
