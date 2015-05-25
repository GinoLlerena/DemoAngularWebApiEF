using Microsoft.Data.Entity;
using Sistemas.WebModel.Base;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.WebApi.Repositorios.Base
{

    public interface IBaseRepositorio<TObject,T>
    {     
        TObject Get(int id);
        ICollection<TObject> GetAll();
        TObject Add(TObject t);
        TObject Update(TObject updated);
        void Delete(TObject t);
        int Count();
        
    }

    public abstract class BaseRepositorio<TObject, T> : IBaseRepositorio<TObject,T> where T : DbContext where TObject : Entity        {

        protected T Ctx { get; set; }

        public BaseRepositorio(T ctx)
        {
            Ctx = ctx;
        }
        
        public TObject Get(int id)
        {
            return Ctx.Set<TObject>().FirstOrDefault(x => x.Id == id);
        }

        
        public ICollection<TObject> GetAll()
        {
            return Ctx.Set<TObject>().ToList();
        }
        
        public TObject Add(TObject t)
        {
            Ctx.Set<TObject>().Add(t);
            Ctx.SaveChanges();
            return t;
        }
                        
        public TObject Update(TObject updated)
        {
            if (updated == null)
                return null;

            Ctx.Set<TObject>().Update(updated);
            Ctx.SaveChanges();
            
            return updated;
        }
        
        public void Delete(TObject t)
        {
            Ctx.Set<TObject>().Remove(t);
            Ctx.SaveChanges();
        }
                        
        public int Count()
        {
            return Ctx.Set<TObject>().Count();
        }
        
        public void Dispose()
        {
            Ctx.Dispose();
        }
    }
}
