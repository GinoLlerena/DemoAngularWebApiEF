using Sistemas.WebModel.DTO;
using Sistemas.WebModel.Models;
using Sistemas.WebModel.Views;
using Sistemas.WebApi.Models;
using Sistemas.WebApi.Repositorios.Base;
using System.Collections.Generic;

namespace Sistemas.WebApi.Repositorios.Interfaces
{
    public interface IUnidadRepositorio : IBaseRepositorio<Unidad, SistemaContext>
    {
        UnidadView GetPaginado(int page);
        List<UnidadDTO> GetDtoAll();
    }
}
