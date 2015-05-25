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
    public class UnidadRepositorio : BaseRepositorio<Unidad, SistemaContext>, IUnidadRepositorio
    {
        public UnidadRepositorio(SistemaContext ctx): base(ctx)
        {

        }

        public List<UnidadDTO> GetDtoAll()
        {

            var Unidades = Ctx.Unidades.Select(b => DtoTranslator.TranslateToUnidadDTO(b));
            return Unidades.ToList();
        }

        public UnidadView GetPaginado(int page)
        {
            UnidadView unidad = new UnidadView() {

                Unidades = Ctx.Unidades
                                .OrderBy(e => e.Nemonico)
                                .Skip(10 * (page - 1))
                                .Take(10)
                                .Select(b => DtoTranslator.TranslateToUnidadDTO(b)),
                Count = Ctx.Unidades.Count()
            };

            return unidad;
        }
    }
}
