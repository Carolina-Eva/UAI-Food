using BE;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PedidoRepository
    {
        private readonly Acceso _acceso = new Acceso();
        PedidoMapper pedidoMapper = new PedidoMapper();

        public async Task<int> GuardarPedidoAsync(Pedido pedido)
        {
            if (pedido == null)
            {
                return 0;
            }

            string sql = $"GUARDAR_PEDIDO";
            var parametros = new List<SqlParameter>
            {
                _acceso.CreateParameter("@Usuario", pedido.Usuario),
                _acceso.CreateParameter("@CostoTotal", pedido.CostoTotal),
                _acceso.CreateParameter("@Combo", pedido.Combo),
                _acceso.CreateParameter("@Fecha", pedido.Fecha)
            };

            int result = await _acceso.ExecuteWriteAsync(sql, parametros);
            return result;
        }

        public async Task<List<Pedido>> ObtenerPedidosAsync()
        {
            string sql = $"LISTAR_PEDIDOS";
            var pedidos = new List<Pedido>();

            var table = await _acceso.GetDataAsync(sql);

            // Assuming there is a method to fetch "agregados" rows for each pedido
            var agregadosTable = await _acceso.GetDataAsync("LISTAR_AGREGADOS");

            var list = new List<Pedido>();

            foreach (DataRow row in table.Rows)
            {
                //list.Add(pedidoMapper.MapearPedido(row));
            }
            return list;
        }
    }

}
