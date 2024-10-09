using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AM.Core.Domain
{
    public class Traveller : Passenger
    {
        public string Healthinformation { get; set; }
        public string Nationality { get; set; }
     public override string ToString()
        {

            return base.ToString() +
                "Healthinformation:" + Healthinformation
                + "Nationality:" + Nationality;
                 
        }
        public override string GetPassengerType()
        {
            return "I am a Traveller ";
        }
    }
}
