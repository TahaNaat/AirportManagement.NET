using System.Collections.Generic;

namespace AM.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(int id);
        T Get(string id);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        //void Save(); 
    }
}