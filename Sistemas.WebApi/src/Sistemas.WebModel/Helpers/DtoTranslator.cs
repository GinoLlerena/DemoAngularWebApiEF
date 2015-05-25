using Sistemas.WebModel.DTO;
using Sistemas.WebModel.Models;

namespace WebModel.Helpers
{
    public static class DtoTranslator
    {
        public static UnidadDTO TranslateToUnidadDTO(Unidad unidad)
        {
            return new UnidadDTO(unidad.Id, unidad.Nemonico, unidad.Descripcion);
        }

        public static ProductoDTO TranslateToProductoDTO(Producto producto)
        {
            return new ProductoDTO(producto.Id, producto.Nombre, producto.Precio, producto.Unidad);
        }

    }
}
