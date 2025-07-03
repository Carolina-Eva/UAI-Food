namespace DAL
{
    using System.Data;
    using BE;
    internal class ProductoMapper
    {
        public static ProductoBase MapearProducto(DataRow row)
        {
            return new ProductoDTO
            {
                Id = Convert.ToInt32(row["ProductoId"]),
                Nombre = row["Nombre"]?.ToString() ?? string.Empty,
                Precio = Convert.ToDouble(row["Precio"]),
                esAgregado = Convert.ToBoolean(row["esAgregado"])
            };
        }
    }
}
