using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Sistemas.WebApi.Repositorios.Interfaces;
using Sistemas.WebApi.Models;
using WebModel.Helpers;
using Sistemas.WebModel.DTO;
using Sistemas.WebModel.Models;
using Microsoft.Data.Entity.Update;
using Sistemas.WebModel.Views;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistemas.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class UnidadController : Controller
    {
        IUnidadRepositorio repo;

        public UnidadController(IUnidadRepositorio _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        [Route("paging/{page}")]
        public IActionResult  GetPaging(int page)
        {
            UnidadView unidadView = repo.GetPaginado(page);
            if (unidadView == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(unidadView) ;
        }


        [HttpGet]
        public IEnumerable<UnidadDTO> GetAll()
        {
            return repo.GetDtoAll(); ;
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UnidadDTO unidad = DtoTranslator.TranslateToUnidadDTO(repo.Get(id));
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(unidad);
        }

        
        [HttpPost]
        public void Post([FromBody]UnidadDTO unidad)
        {
            if (!ModelState.IsValid)
                Context.Response.StatusCode = 400;
            else
            {
                repo.Add(EfTranslator.TranslateToUnidad(unidad));
                Context.Response.StatusCode = 201; // Created
            }
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UnidadDTO unidad)
        {
            if (!ModelState.IsValid)
                Context.Response.StatusCode = 400;
            else
            {
                if (id != unidad.Id)
                    Context.Response.StatusCode = 400;
                else
                {
                    
                    repo.Update(EfTranslator.TranslateToUnidad(unidad));
                    Context.Response.StatusCode = 200; //OK
                }
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Unidad unidad = repo.Get(id);

            if (unidad == null)
                return HttpNotFound();
            else
                repo.Delete(unidad);
                
            return new HttpStatusCodeResult(204);
        }
    }
}
