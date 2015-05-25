using Sistemas.WebModel.DTO;
using Sistemas.WebModel.Models;

namespace WebModel.Helpers
{
    public static class EfTranslator
    {
        public static Unidad TranslateToUnidad(UnidadDTO unidad)
        {
            return new Unidad(unidad.Id, unidad.Nemonico, unidad.Descripcion);
        }

        public static Producto TranslateToProducto(ProductoDTO producto)
        {
            return new Producto(producto.Id, producto.Nombre, producto.Precio, producto.UnidadID);
        }
        
    }
}
