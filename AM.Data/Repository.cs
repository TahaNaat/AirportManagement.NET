using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Interfaces;

namespace AM.Data
{
   
    public class Repository<T> : IRepository<T> where T : class
    {
        AMContext context;
        public Repository(AMContext context)
        { this.context = context; }
        public void Add(T t)
        { context.Add(t); }
        //TP6 Q10
        //public void Commit()
        //{ context.SaveChanges();}
        public void Delete(T t)
        { context.Remove(t); }
        public T Get(int id)
        { return (T)(context.Find(typeof(T), id)); }
        public T Get(string id)
        { return (T)(context.Find(typeof(T), id)); }
        public IList<T> GetAll()
        { return context.Set<T>().ToList(); }
        public void Update(T t)
        { context.Update(t); }
    }


}