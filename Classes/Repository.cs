using System.Collections.Generic;
using CrudSeries.Interfaces;

namespace CrudSeries
{
    public class Repository : IRepository<Series>
    {
        private List<Series> fullList = new List<Series>();

        public void Insert(Series entity)
        {
            fullList.Add(entity);
        }

        public Series GetById(int id)
        {
            return fullList[id];
        }

        public void Update(int id, Series entity)
        {
            fullList[id] = entity;
        }

        public void Delete(int id)
        {
            fullList[id].Deleted = true;
        }

        public List<Series> SeriesList()
        {
            return fullList;
        }

        public int NextId()
        {
            return fullList.Count;
        }
    }
}
