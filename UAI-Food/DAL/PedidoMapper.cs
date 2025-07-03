using BE;
using System.Data;

namespace DAL
{
    internal class PedidoMapper
    {
        public static Pedido MapearPedido(DataRow row)
        {
            return new Pedido
            {
                Id = Convert.ToInt32(row["Id"]),
                Usuario = new Usuario(
                    Convert.ToInt32(row["UsuarioId"]),
                    row["UsuarioDescripcion"]?.ToString() ?? string.Empty
                ),
                Fecha = Convert.ToDateTime(row["Fecha"]),
                CostoTotal = Convert.ToInt32(row["CostoTotal"]),
                ComboDescription = row["ComboDescripcion"]?.ToString() ?? string.Empty
            };
        }

    }
}
