using CarFuel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Service
{
   public abstract class ServiceBase<T> : IService<T> where T : class {

    private readonly IRepository<T> _BaseRepo;

    public ServiceBase(IRepository<T> baseRepo) {
      if (baseRepo == null) {
       // throw new ArgumentNullException(nameof(baseRepo));
          throw new ArgumentNullException("baseRepo");
      }
      _BaseRepo = baseRepo;
    }

    public abstract T Find(params object[] keys);

    public virtual T Add(T item) {
        return _BaseRepo.Add(item);
    }

    public virtual IQueryable<T> All() { 
        return  Query(_ => true);
        }

    public virtual IQueryable<T> Query(Func<T, bool> criteria) { return  _BaseRepo.Query(criteria);}

    public virtual T Remove(T item) { return  _BaseRepo.Remove(item);}

    public virtual int SaveChanges() { return  _BaseRepo.SaveChanges();}

  }
}
