using BE;
using System.Data;

namespace DAL
{
    internal class PedidoMapper
    {
        public static Pedido MapearPedido(DataRow pedidoRow, List<DataRow> agregadosRows)
        {
            // Combo base
            string baseDescripcion = pedidoRow["TipoComboDescripcion"].ToString();
            Combo combo = baseDescripcion switch
            {
                "Combo Basico" => new ComboBasico(),
                "Combo Especial" => new ComboEspecial(),
                "Combo Familiar" => new ComboFamiliar(),
                _ => throw new InvalidOperationException("Combo no reconocido.")
            };

            // Decorar combo con agregados
            foreach (var agregadoRow in agregadosRows)
            {
                string agregado = agregadoRow["AgregadoDescripcion"].ToString();
                combo = agregado switch
                {
                    "Papa" => new Papa(combo),
                    "Tomate" => new Tomate(combo),
                    "Carne" => new Carne(combo),
                    "Queso" => new Queso(combo),
                    _ => combo
                };
            }

            // Fix for CS8604: Ensure "UsuarioDescripcion" is not null
            string usuarioDescripcion = pedidoRow["UsuarioDescripcion"]?.ToString() ?? throw new InvalidOperationException("UsuarioDescripcion no puede ser nulo.");

            return new Pedido
            {
                Id = Convert.ToInt32(pedidoRow["Id"]),
                Fecha = Convert.ToDateTime(pedidoRow["Fecha"]),
                CostoTotal = Convert.ToInt32(pedidoRow["CostoTotal"]),
                Usuario = new Usuario(
                    Convert.ToInt32(pedidoRow["UsuarioId"]),
                    usuarioDescripcion
                ),
                Combo = combo
            };
        }
    }
}
