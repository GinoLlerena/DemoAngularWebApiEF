using Microsoft.AspNet.Mvc;
using Sistemas.WebApi.Repositorios.Interfaces;
using Sistemas.WebModel.Views;
using Sistemas.WebModel.DTO;
using WebModel.Helpers;
using Sistemas.WebModel.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistemas.WeApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        IProductoRepositorio repo;

        public ProductoController(IProductoRepositorio _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        [Route("paging/{page}")]
        public IActionResult GetPaging(int page)
        {
            ProductsView productoView = repo.GetPaginado(page);
            if (productoView == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(productoView); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ProductoDTO producto = repo.GetProductoDTO(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(producto);
        }

        [HttpPost]
        public void Post([FromBody]ProductoDTO producto)
        {
            if (!ModelState.IsValid)
                Context.Response.StatusCode = 400; // Bad Request
            else
            {
                repo.Add(EfTranslator.TranslateToProducto(producto));
                Context.Response.StatusCode = 201; // Created
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductoDTO producto)
        {
            if (!ModelState.IsValid)
                Context.Response.StatusCode = 400; // Bad Request
            else
            {
                if (id != producto.Id)
                    Context.Response.StatusCode = 400; // Bad Request
                else
                {
                    repo.Update(EfTranslator.TranslateToProducto(producto));
                    Context.Response.StatusCode = 200; //OK
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Producto producto = repo.Get(id);

            if (producto == null)
                return HttpNotFound();
            else
                repo.Delete(producto);

            return new HttpStatusCodeResult(204);
        }
    }
}
