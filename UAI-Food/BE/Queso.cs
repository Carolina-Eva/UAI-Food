namespace BE
{
    public class Queso : AgregadoDecorator
    {
        public Queso(Combo comida) : base(comida) { }
        public override double Costo => _combo.Costo + 2.5;
        public override string Descripcion => string.Format($"{_combo.Descripcion}, Queso");
    }
}
