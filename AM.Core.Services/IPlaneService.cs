using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IPlaneService : IService<Plane>
    {
        // TP6 --> Q5
        //void Add(Plane plane);
        //void Delete(Plane plane);
        //IList<Plane> GetAll();
        public IList<Passenger> GetPassengers(Plane p);
        public IList<Flight> GetFlight(int n);
        public bool IsAvailable(Flight flight, int n);
        public void DeleteUselessPlanes();

    }
}