using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
     public class Flight 
    {
        public string Destination { get; set; }
        public string Depature { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimateDuration { get; set; }
        public IList<Passenger> Passengers { get; set; }
        public Plane MyPlane { get; set; }

        
        public override string ToString() {
            return "Destination:"+Destination 
                + "Depature:" + Depature 
                + "FlightDate:"+FlightDate 
                + "EffectiveArrival:" + EffectiveArrival 
                + "EstimateDuration:"+EstimateDuration
                + "MyPlane:{" + MyPlane+ "}"
                + "FlightId:" + FlightId;
        }
    }
}
