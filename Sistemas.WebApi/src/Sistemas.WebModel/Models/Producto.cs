//-----------------------------------------------------------//
//                                                           //
//  Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                           //
//-----------------------------------------------------------//

using Sistemas.WebModel.Base;

namespace Sistemas.WebModel.Models
{
    public class Producto : Entity
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public int UnidadID { get; set; }

        public virtual Unidad Unidad { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, decimal precio, int unidadID)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            UnidadID = unidadID;
        }
    }
}
