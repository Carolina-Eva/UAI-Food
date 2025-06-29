namespace BE
{
    public abstract class AgregadoDecorator : Combo
    {
        protected Combo _combo;
        public Combo ComboBase => _combo;
        public AgregadoDecorator(Combo combo)
        {
            _combo = combo;
        }
    }
}
