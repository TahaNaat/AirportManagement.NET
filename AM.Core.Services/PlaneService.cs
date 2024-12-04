using AM.Core.Domain;
using System;
using AM.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class PlaneService : Service<Plane>, IPlaneService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaneService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IList<Flight> GetFlight(int n)
        {
            return GetAll()
                .OrderByDescending(P => P.ManufactureDate)
                .Take(n)
                .SelectMany(p => p.Flights)
                .OrderBy(f => f.FlightDate)
                .ToList();
        }

        public IList<Passenger> GetPassengers(Plane p)
        {
            return Get(p.PlaneId).Flights.SelectMany(f => f.Reservations)
                .Select(r => r.MyPassenger)
                .Distinct().ToList();
        }

        public bool IsAvailable(Flight flight, int n)
        {
            var plane = flight.MyPlane;
            int reservedSeats = flight.Reservations.Count();
            return (plane.Capacity - reservedSeats) >= n;
        }
        public void DeleteUselessPlanes()
        {
            var oneYearAgo = DateTime.Now.AddYears(-1);

            var unusedPlanes = GetAll()
                .Where(p => !p.Flights.Any(f => f.FlightDate >= oneYearAgo))
                .ToList();

            foreach (var plane in unusedPlanes)
            {
                Delete(plane);
            }

            _unitOfWork.Save();
        }

    }
}
