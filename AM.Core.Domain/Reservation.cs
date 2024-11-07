
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {

        public int Price { get; set; }
        public string Seat { get; set; }
        public bool Vip { get; set; }
        public virtual Passenger MyPassenger { get; set; }
        public string PassengerId { get; set; }
        public virtual Flight MyFlight { get; set; }
        public int FlightId { get; set; }
    }
}
