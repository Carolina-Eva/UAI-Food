using BE;
using DAL;

namespace BLL
{
    public class ProductoManager
        
    {
        private readonly ProductoRepository _productoRepository = new ProductoRepository();
        public async Task<List<ProductoBase>> ObtenerProductosAsync()
        {
            return await _productoRepository.ObtenerProductos();
        }

        public async Task<List<ProductoBase>> ObtenerAgregados()
        {
            return await _productoRepository.ObtenerAgregados();
        }

        public async Task<List<ProductoBase>> ObtenerCombos()
        {
            return await _productoRepository.ObtenerCombos();
        }


    }
}
