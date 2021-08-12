using System.Collections.Generic;

namespace CrudSeries.Interfaces
{
    public interface IRepository<T>
    {
        List<T> SeriesList();
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
