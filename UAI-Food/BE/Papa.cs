namespace BE
{
    public class Papa : AgregadoDecorator
    {
        public Papa(Combo combo) : base(combo) { }
        public override double Costo => _combo.Costo + 2.5;
        public override string Descripcion => string.Format($"{_combo.Descripcion}, Papa");
    }
}
