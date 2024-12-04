using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    internal class PlaneRepository: IPlaneRepository
    {
        AMContext context;
        public PlaneRepository(AMContext context)
        { this.context = context; }
        public void Add(Plane plane)
        { context.Add(plane);
          context.SaveChanges();
        }
      
        public void Delete(Plane plane)
        { context.Remove(plane);
          context.SaveChanges();
        }
        public Plane Get(int id)
        { return context.Find<Plane>(id); }
        public IList<Plane> GetAll()
        { return context.Set<Plane>().ToList(); }
        public void Update(Plane plane)
        { context.Update(plane);
          context.SaveChanges();
        }
    }

}

