using Microsoft.EntityFrameworkCore;
using Product.API.Models.Domain;

using System.Linq;

namespace Product.API.Respositories.Implementation
{
  public abstract class BaseRepository<T> where T:class
  {

      private readonly DbContext _Context;
      private IQueryable<T> _entities => _Context.Set<T>();
      public BaseRepository(DbContext context)
      {
        this._Context = context;
      }
      public virtual List<T> Get() => _entities.ToList();
      public virtual IQueryable<T> GetAll() => _entities;
      public virtual T Add(T t)
      {
        _Context.Set<T>().Add(t);
        return t;
      }
      public T Delete(T t)
      {
        this._Context.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

        return t;
      }
      public T Update(int id, T t)
      {
        this._Context.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        return t;
      }

   
}
}
