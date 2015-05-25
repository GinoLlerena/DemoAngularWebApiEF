using Microsoft.Data.Entity;
using Sistemas.WebModel.DTO;
using Sistemas.WebModel.Models;
using Sistemas.WebModel.Views;
using Sistemas.WebApi.Models;
using Sistemas.WebApi.Repositorios.Base;
using Sistemas.WebApi.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;
using WebModel.Helpers;

namespace Sistemas.WebApi.Repositorios
{
    public class ProductoRepositorio : BaseRepositorio<Producto, SistemaContext>, IProductoRepositorio
    {
        public ProductoRepositorio(SistemaContext ctx): base(ctx)
        {

        }

        public ProductoDTO GetProductoDTO(int id)
        {
            Producto b = Ctx.Productos
                            .Include(y => y.Unidad)
                            .FirstOrDefault(x => x.Id == id);
            return DtoTranslator.TranslateToProductoDTO(b);
        }

        public IList<ProductoDTO> GetAllProductoDTO()
        {
            var productos = Ctx.Productos
                                .Include(x => x.Unidad)
                                .Select(b => DtoTranslator.TranslateToProductoDTO(b)).ToList();

            return productos;
        }

        public ProductsView GetPaginado(int page)
        {
            var z = Ctx.Productos
                    .Include(x => x.Unidad)
                    .OrderBy(e => e.Nombre)
                    .Skip(10 * (page - 1))
                    .Take(10)
                    .ToList();

            int iTotal = Ctx.Productos.Count();


            ProductsView producto = new ProductsView() {
                                        Productos = z.ToList().Select(b => DtoTranslator.TranslateToProductoDTO(b)).ToList(),
                                        Count = iTotal
                                };

            return producto;
        }
    }
}
