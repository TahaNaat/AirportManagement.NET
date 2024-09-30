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
        override
     public string ToString()
        {

            return base.ToString() +
                "Healthinformation:" + Healthinformation
                + "Nationality:" + Nationality;
                 
        }
        public override string GetPassangerType()
        {
            return "I am a traveller";
        }
    }
}
