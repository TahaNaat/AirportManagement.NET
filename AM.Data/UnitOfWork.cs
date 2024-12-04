using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        AMContext _context;
        public UnitOfWork(AMContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
