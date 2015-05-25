using Sistemas.WebModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.WebApi.Models
{
    public class SistemaContextInicialice 
    {
        private SistemaContext _ctx;

        public SistemaContextInicialice(SistemaContext ctx)
        {
            _ctx = ctx;
        }

        public void InitializeData()
        {
            if (_ctx.Database.EnsureCreated()){
                Seed();
            }
        }

        private void Seed()
        {

            if (_ctx.Unidades.Count() == 0){

                
                var Unidades = new List<Unidad>{
                    new Unidad{Descripcion = "Metros", Nemonico="MTO"},
                    new Unidad{Descripcion = "Kilogramo", Nemonico="KGR"},
                    new Unidad{Descripcion = "Litro", Nemonico="LTO"},
                    new Unidad{Descripcion = "Unidad", Nemonico="UND"},
                };

                Unidades.ForEach(u => _ctx.Unidades.Add(u));


                var Productos = new List<Producto>{
                    new Producto{Nombre = "Cable Electrico", Precio = 10.35M, Unidad = Unidades.Single(a => a.Nemonico == "MTO") },
                    new Producto{Nombre = "Anilina Negra", Precio = 11.35M, Unidad = Unidades.Single(a => a.Nemonico == "KGR") },
                    new Producto{Nombre = "Aceite Ligero", Precio = 14.35M, Unidad = Unidades.Single(a => a.Nemonico == "LTO") },
                    new Producto{Nombre = "Tornillos", Precio = 8.35M, Unidad = Unidades.Single(a => a.Nemonico == "UND") },
                    new Producto{Nombre = "Clavos", Precio = 5.35M, Unidad = Unidades.Single(a => a.Nemonico == "UND") }

                };

                Productos.ForEach(u => _ctx.Productos.Add(u));

                _ctx.SaveChanges();



                
            }

        }
    }
}
