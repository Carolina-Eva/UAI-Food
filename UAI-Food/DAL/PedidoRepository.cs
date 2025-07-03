using BE;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PedidoRepository
    {
        private readonly Acceso _acceso = new Acceso();
        private static readonly PedidoMapper pedidoMapper = new PedidoMapper();

        public async Task<int> GuardarPedidoAsync(Pedido pedido)
        {
            if (pedido == null)
                return 0;

            string sql = "GUARDAR_PEDIDO";

            var parametros = new List<SqlParameter>
            {
                _acceso.CreateParameter("@UsuarioId", pedido.Usuario.Id),
                _acceso.CreateParameter("@ComboDescripcion", pedido.ComboDescription),
                _acceso.CreateParameter("@Fecha", pedido.Fecha),
                _acceso.CreateParameter("@CostoTotal", (float)pedido.CostoTotal)
            };

            int result =  await _acceso.ExecuteWriteAsync(sql, parametros);
            return result;
        }


        public async Task<List<Pedido>> ObtenerPedidosAsync()
        {
            var list = new List<Pedido>();
            string sql = $"LISTAR_PEDIDOS";
            var table = await _acceso.GetDataAsync(sql);

            foreach (DataRow row in table.Rows)
            {
                list.Add(PedidoMapper.MapearPedido(row));
            }
            return list;
        }
        public async Task<List<Pedido>> ObtenerPedidosPorUsuarioAsync(int Id)
        {
            var list = new List<Pedido>();
            string sql = $"LISTAR_PEDIDOS_POR_USUARIO";
            var parametros = new List<SqlParameter>
            {
                _acceso.CreateParameter("@UsuarioId", Id)
            };
            var table = await _acceso.GetDataAsync(sql, parametros);

            foreach (DataRow row in table.Rows)
            {
                list.Add(PedidoMapper.MapearPedido(row));
            }
            return list;
        }
    }

}
