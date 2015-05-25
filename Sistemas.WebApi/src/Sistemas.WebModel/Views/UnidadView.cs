using Sistemas.WebModel.DTO;
using System.Linq;

namespace Sistemas.WebModel.Views
{
    public class UnidadView
    {
        public IQueryable<UnidadDTO> Unidades { get; set; }
        public int Count { get; set; }
    }
}
