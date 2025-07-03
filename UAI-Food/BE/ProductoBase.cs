
namespace BE
{
    public abstract class ProductoBase
    {
        protected ProductoBase(){}
        public virtual string Nombre { get; set; } = string.Empty;
        public virtual double Precio { get; set; }
        public virtual bool esAgregado { get; set; }
    }

}
