using BE;

public abstract class AgregadoDecorator : ProductoBase
{
    protected ProductoBase _combo;

    public ProductoBase ComboDecorator => _combo;

    protected AgregadoDecorator(ProductoBase combo)
    {
        _combo = combo;
    }
    public override abstract double Precio { get; }
    public override abstract string Nombre { get; }
    public override abstract bool esAgregado { get; set; }
}
