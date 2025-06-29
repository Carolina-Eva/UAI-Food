using BE;
using DAL;

namespace BLL
{
    public class PedidoManager
    {
        private PedidoRepository _pedidoRepository = new PedidoRepository();

        public async Task<int> CrearPedido(Pedido pedido)
        {
            int result;
            if (pedido == null)
            {
                throw new ArgumentNullException("El pedido no puede ser nulo.");
            }
            else
                result = await _pedidoRepository.GuardarPedidoAsync(pedido);

            return result;
        }

        public async Task <List<Pedido>> ListarPedidosPorUsuario(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del usuario debe ser mayor que cero.");
            }
            List<Pedido> pedidos = await _pedidoRepository.ObtenerPedidosAsync();
            return pedidos;
        }

        public async Task<List<Pedido>> ListarPedidos()
        {
            List<Pedido> pedidos = await _pedidoRepository.ObtenerPedidosAsync();
            return pedidos;
        }
    }
}
