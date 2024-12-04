using AM.Core.Domain;
using AM.Core.Interfaces;
using AM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class Service<T> : IService<T> where T : class
    {
        IRepository<T> repository;
        readonly IUnitOfWork unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<T>();
        }
        public void Add(T t)
        {
            repository.Add(t);
            // repository.Commit();
            unitOfWork.Save();
        }

        public void Delete(T t)
        {
            repository.Delete(t);
            unitOfWork.Save();
        }

        public T Get(string id)
        {
            return repository.Get(id);
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public IList<T> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(T t)
        {
            repository.Update(t);
            unitOfWork.Save();
        }
    }
}