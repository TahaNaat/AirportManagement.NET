using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency,ErrorMessage ="currency invalide")]
        public int Salary { get; set; }
        
       public override string ToString()
        {
            return base.ToString() +
                "EmployementDate:" + EmployementDate 
                + "Function:" + Function 
                + "Salary:"  + Salary;
        }
        public override string GetPassengerType()
        {
            return "I am a passenger I am a Staff Member»";
        }
    }
}
