namespace BE
{
    public class Tomate : AgregadoDecorator
    {
        private readonly string _nombreAgregado;
        private readonly double _precioAgregado;

        public Tomate(ProductoBase combo, string nombreAgregado, double precioAgregado)
            : base(combo)
        {
            _nombreAgregado = nombreAgregado;
            _precioAgregado = precioAgregado;
            esAgregado = true;
        }
        public override double Precio => _combo.Precio + _precioAgregado;
        public override string Nombre => $"{_combo.Nombre}, {_nombreAgregado}";
        public override bool esAgregado { get; set; }
    }
}
