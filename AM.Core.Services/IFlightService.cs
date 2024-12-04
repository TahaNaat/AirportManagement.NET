using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService : IService<Flight>
    {
        IList<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        /// <summary>
        /// retourne le nombre de vols programmés pour une semaine à partir d’une date donnée.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        int GetWeeklyFlightNumber(DateTime date);
        double GetDurationAverage(string destination);
        IList<Flight> SortFlights();
        IList<Passenger> GetThreeOlderTravellers(Flight flight);
        void ShowGroupedFlights();
        public delegate int GetScore(Passenger p); // methode annonyme
        Passenger GetSeniorPassenger(GetScore meth);

        // TP6 --> Q2
        //void Add(Flight flight);
        //void Delete(Flight flight);
        //IList<Flight> GetAll();
    }
}
