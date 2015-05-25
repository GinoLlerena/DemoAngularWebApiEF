using Sistemas.WebModel.DTO;
using System.Collections.Generic;

namespace Sistemas.WebModel.Views
{
    public class ProductsView
    {
        public IList<ProductoDTO> Productos { get; set; }
        public int Count { get; set; }

        public ProductsView() {
            Productos = new List<ProductoDTO>();
            Count = 0;  
        }
    }
}
