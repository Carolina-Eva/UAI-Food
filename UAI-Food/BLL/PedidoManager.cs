using BE;
using DAL;

namespace BLL
{
    public class PedidoManager
    {
        private PedidoRepository _pedidoRepository = new PedidoRepository();

        public async Task<int> CrearPedido(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException("El pedido no puede ser nulo.");

            var (comboDescripcion, agregadosTexto, costoTotal) = DescomponerPedido(pedido);

            pedido.Combo = new ComboGenerico(comboDescripcion, costoTotal);
            pedido.Agregados = agregadosTexto.Split(", ").ToList();
            pedido.CostoTotal = costoTotal;

            return await _pedidoRepository.GuardarPedidoAsync(pedido);
        }

        private (string comboBase, string agregadosTexto, double costoTotal) DescomponerPedido(Pedido pedido)
        {
            if (pedido == null || pedido.Combo == null)
                throw new ArgumentNullException("El pedido o el combo no puede ser nulo.");

            var agregados = new List<string>();
            Combo actual = pedido.Combo;

            // Recorrer la cadena de decoradores hasta el combo base
            while (actual is AgregadoDecorator decorador)
            {
                // Obtenemos solo el nombre del agregado actual (asumiendo formato: "... , Queso")
                string descripcionCompleta = decorador.Descripcion;
                string descripcionBase = decorador.ComboBase.Descripcion;

                // Extraer solo el agregado actual (por diferencia entre descripciones)
                string agregado = descripcionCompleta.Replace(descripcionBase, "").TrimStart(' ', ',');
                agregados.Add(agregado);

                actual = decorador.ComboBase;
            }

            agregados.Reverse(); // Respetar el orden de selección original
            string comboBase = actual.Descripcion;
            string agregadosTexto = string.Join(", ", agregados);
            double costoTotal = pedido.Combo.Costo;

            return (comboBase, agregadosTexto, costoTotal);
        }



        public async Task <List<Pedido>> ListarPedidosPorUsuario(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del usuario debe ser mayor que cero.");
            }
            List<Pedido> pedidos = await _pedidoRepository.ObtenerPedidosPorUsuarioAsync(id);
            return pedidos;
        }

        public async Task<List<Pedido>> ListarPedidos()
        {
            List<Pedido> pedidos = await _pedidoRepository.ObtenerPedidosAsync();
            return pedidos;
        }
    }
}
