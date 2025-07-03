namespace BE
{
    public class Papa : AgregadoDecorator
    {
        private readonly string _nombreAgregado;
        private readonly double _precioAgregado;

        public Papa(ProductoBase combo, string nombreAgregado, double precioAgregado)
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
