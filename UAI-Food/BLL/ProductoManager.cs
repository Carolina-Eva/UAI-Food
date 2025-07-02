using DAL;

namespace BLL
{
    public class ProductoManager
        
    {
        private readonly ProductoRepository _productoRepository = new ProductoRepository();
        public async Task<List<BE.Producto>> ObtenerProductosAsync()
        {
            return await _productoRepository.ObtenerProductos();
        }

        public async Task<List<BE.Producto>> ObtenerAgregados()
        {
            return await _productoRepository.ObtenerAgregados();
        }

        public async Task<List<BE.Producto>> ObtenerCombos()
        {
            return await _productoRepository.ObtenerCombos();
        }


    }
}
