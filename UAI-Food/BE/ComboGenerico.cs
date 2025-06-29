namespace BE
{
    public class ComboGenerico : Combo
    {
        private readonly string _descripcion;
        private readonly double _costo;

        public ComboGenerico(string descripcion, double costo)
        {
            _descripcion = descripcion;
            _costo = costo;
        }

        public override string Descripcion => _descripcion;
        public override double Costo => _costo;
    }
}
