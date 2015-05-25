//-----------------------------------------------------------//
//                                                           //
//  Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                           //
//-----------------------------------------------------------//

using Sistemas.WebModel.Base;

namespace Sistemas.WebModel.Models
{
    public class Unidad : Entity
    {
        public string Nemonico { get; set; }
        public string Descripcion { get; set; }

        public Unidad() { }
        public Unidad(int id, string nemonico, string descripcion)
        {
            Id = id;
            Nemonico = nemonico;
            Descripcion = descripcion;
        }
    }
}
