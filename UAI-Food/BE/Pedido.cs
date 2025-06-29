namespace BE
{
    public class Pedido
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Combo? Combo { get; set; }
        public double CostoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public List<string> Agregados { get; set; } = new();
    }
}
