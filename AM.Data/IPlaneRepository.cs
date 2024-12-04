using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    internal interface IPlaneRepository
    {
        void Add(Plane entity);
        void Delete(Plane entity);
        Plane Get(int id);
        IList<Plane> GetAll();
        void Update(Plane entity);
    }
}
