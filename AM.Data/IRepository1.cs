using System.Collections.Generic;

namespace AM.Data
{
    internal interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(int id);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
    }
}