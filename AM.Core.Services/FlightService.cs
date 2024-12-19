using AM.Core.Domain; //ajouter refernce
using AM.Core.Interfaces;
using AM.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AM.Core.Services
{
    public class FlightService : Service<Flight>, IFlightService
    {
        //IRepository<Flight> repository;
        //IUnitOfWork unitOfWork;
        public IList<Flight> Flights { get; set; } //prop

        public FlightService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //this.unitOfWork = unitOfWork;
            //repository = unitOfWork.GetRepository<Flight>();
            Flights = GetAll();
        }

        //Le langage LINQ
        //public IList<Flight> Flights { get; set; } //prop

        //public IList<DateTime> GetFlightDates(string destination)
        //{
        //    IList<DateTime> listeDate=new List<DateTime>(); 
        //    foreach (var flight in Flights)
        //    {
        //        if (flight.Destination==destination)
        //        {
        //            listeDate.Add(flight.FlightDate);
        //        }
        //    }
        //    return listeDate;
        //}
        public IList<DateTime> GetFlightDates(string destination) // linqIntegre
        {
            //return (from f in Flights 
            //       where f.Destination == destination
            //       select f.FlightDate).ToList();
            return Flights.Where(f => f.Destination.ToString() == destination) //Methoded'extention
                .Select(f => f.FlightDate).ToList();

        }

        public void GetFlights(string filterType, string filterValue)
        {

            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightId":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightId.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":

                    foreach (var flight in Flights)
                    {
                        // if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                        if (flight.EffectiveArrival.ToString() == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    try
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EstimateDuration == int.Parse(filterValue))
                            {
                                Console.WriteLine(flight);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("la valeur du filter n'est pas un int : ", ex.ToString());
                    }
                    break;
            }
        }



        public void ShowFlightDetails(Plane plane)
        {
            var result = from f in Flights
                         where f.MyPlane.PlaneId == plane.PlaneId
                         select new { f.Destination, f.FlightDate }; //type anonyme
            foreach (var item in result)
            {
                Console.WriteLine("destination : " + item.Destination +
                    "date :" + item.FlightDate);
            }
        }
        public int GetWeeklyFlightNumber(DateTime date)
        {
            return (from f in Flights
                    where f.FlightDate >= date
                    && f.FlightDate < date.AddDays(7)
                    select f).Count(); //type anonyme

        }


        public double GetDurationAverage(string destination)
        {
            return (from f in Flights
                    where f.Destination.ToString() == destination
                    select f.EstimateDuration).Average();
        }

        public IList<Flight> SortFlights()
        {
            return (from f in Flights
                    orderby f.EstimateDuration descending
                    select f).ToList();
        }
        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            //return (from p in flight.passengers
            //        orderby p.Age descending //orderby p.BirthDate
            //        select p).Take(3).ToList();
            return null;
        }

        public void ShowGroupedFlights()
        {
            /*var */
            IEnumerable<IGrouping<string, Flight>> result = from f in Flights
                                                            group f by f.Destination.ToString();
            foreach (var grp in result)
            {
                Console.WriteLine(grp.Key);
                foreach (var f in grp)
                {
                    Console.WriteLine(f);

                }
            }
        }

        //Les méthodes anonymes
        public Passenger GetSeniorPassenger(IFlightService.GetScore meth)
        {
            //var result = (from f in Flights
            //              from p in f.passengers
            //              orderby meth(p) descending
            //              select p).First();
            //return result;
            return null;
        }
        //TP6 --> Q2
        //public void Add(Flight flight)
        //{
        //    repository.Add(flight);
        //    // repository.Commit();
        //    unitOfWork.Save();
        //}
        //public void Delete(Flight flight)
        //{
        //    repository.Delete(flight);
        //    //repository.Commit();
        //    unitOfWork.Save();
        //}

        //public IList<Flight> GetAll()
        //{
        //    return repository.GetAll();
        //}
    }

}