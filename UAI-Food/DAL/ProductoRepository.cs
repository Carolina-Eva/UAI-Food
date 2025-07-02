using System.Data;
using BE;

namespace DAL
{
    public class ProductoRepository
    {
        private readonly Acceso _acceso = new Acceso();
        public async Task<List<Producto>> ObtenerProductos()
        {
            var list = new List<Producto>();
            string sql = $"GET_ALL_PRODUCTOS";
            var table = await _acceso.GetDataAsync(sql);

            foreach (DataRow row in table.Rows)
            {
                list.Add(ProductoMapper.MapearProducto(row));
            }
            return list;
        }

        public async Task<List<Producto>> ObtenerCombos()
        {
            var list = new List<Producto>();
            string sql = $"GET_COMBOS";
            var table = await _acceso.GetDataAsync(sql);

            foreach (DataRow row in table.Rows)
            {
                list.Add(ProductoMapper.MapearProducto(row));
            }
            return list;
        }

        public async Task<List<Producto>> ObtenerAgregados()
        {
            var list = new List<Producto>();
            string sql = $"GET_AGREGADOS";
            var table = await _acceso.GetDataAsync(sql);

            foreach (DataRow row in table.Rows)
            {
                list.Add(ProductoMapper.MapearProducto(row));
            }
            return list;
        }
    }
}
