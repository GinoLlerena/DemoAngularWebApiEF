//-----------------------------------------------------------//
//                                                           //
//  Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                           //
//-----------------------------------------------------------//
namespace Sistemas.WebModel.DTO
{
    public class UnidadDTO
    {
        public int Id { get; set; }
        public string Nemonico { get; set; }
        public string Descripcion { get; set; }

        public UnidadDTO(int id, string nemonico, string descripcion)
        {
            Id = id;
            Nemonico = nemonico;
            Descripcion = descripcion;
        }

    }
}
