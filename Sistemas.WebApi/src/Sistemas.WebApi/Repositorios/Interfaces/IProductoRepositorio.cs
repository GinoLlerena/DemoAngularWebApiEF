using Sistemas.WebModel.DTO;
using Sistemas.WebModel.Models;
using Sistemas.WebModel.Views;
using Sistemas.WebApi.Models;
using Sistemas.WebApi.Repositorios.Base;
using System.Collections.Generic;

namespace Sistemas.WebApi.Repositorios.Interfaces
{
    public interface IProductoRepositorio : IBaseRepositorio<Producto, SistemaContext>
    {
        ProductoDTO GetProductoDTO(int id);
        IList<ProductoDTO> GetAllProductoDTO();
        ProductsView GetPaginado(int page);
    }
}
