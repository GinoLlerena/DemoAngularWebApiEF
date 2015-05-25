//-----------------------------------------------------------//
//                                                           //
//  Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                           //
//-----------------------------------------------------------//

using Sistemas.WebModel.Models;

namespace Sistemas.WebModel.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int UnidadID { get; set; }
        public string Unidad { get; set; }

        public ProductoDTO() { }

        public ProductoDTO(int id, string nombre, decimal precio, Unidad unidad)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            UnidadID = unidad.Id;
            Unidad = unidad.Nemonico;
        }
    } 


}
