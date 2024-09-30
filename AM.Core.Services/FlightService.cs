using AM.Core.Domain   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public IList<Flight> flights { get; set; } 
    public IList<Flight> GetFlights(string filterType, string filterValue)
    {
        switch (filterType.ToLower())
        {
            case "destination":
                return flights.Where(f => f.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();

            case "departure":
                return flights.Where(f => f.Depature.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();

            case "flightid":
                if (int.TryParse(filterValue, out int flightId))
                    return flights.Where(f => f.FlightId == flightId).ToList();
                else
                    throw new ArgumentException("Invalid Flight ID value");

            case "estimateduration":
                if (int.TryParse(filterValue, out int duration))
                    return flights.Where(f => f.EstimateDuration == duration).ToList();
                else
                    throw new ArgumentException("Invalid Duration value");

            default:
                throw new ArgumentException($"Filter type '{filterType}' is not supported.");
        }
    }
    public IList<DateTime> GetFlightDates(string destination)
    {
        return flights.Where(flight => flight.Destination == destination)
                      .Select(flight => flight.FlightDate) 
                      .ToList();
    }
}
}