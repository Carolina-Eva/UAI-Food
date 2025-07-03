namespace BE
{
    public class Pedido
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string? ComboDescription { get; set; }
        public double CostoTotal { get; set; }
        public DateTime Fecha { get; set; }
     }

    public class PedidoViewModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Combo { get; set; }
        public DateTime Fecha { get; set; }
        public double CostoTotal { get; set; }
    }
}
