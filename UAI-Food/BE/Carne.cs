namespace BE
{
    public class Carne : AgregadoDecorator
    {
        public Carne(Combo combo) : base(combo) { }
        public override double Costo => _combo.Costo + 6.5;
        public override string Descripcion => string.Format($"{_combo.Descripcion}, Carne");
    }
}
