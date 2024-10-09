using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public IList<Flight> Flights { get; set; }
        public int Age { get; set; }

 
       public override string ToString()
        {
            return "BirthDate:" + BirthDate 
                + "PassportNumber:" + PassportNumber 
                + "EmailAddress:" + EmailAddress 
                + "FirstName:" + FirstName 
                + "LastName:" + LastName 
                + "TelNumber:" + TelNumber;
        }
        //public bool CheckProfile(string firstName , string lastName)
        //{
        //    return firstName == FirstName && lastName== LastName;
        //}
        
        //public bool CheckProfile(string firstName, string lastName ,string email)
        //{
        //    return firstName == FirstName && lastName == LastName
        //        && email == EmailAddress;
        //}
        public bool CheckProfile(string firstName, string lastName, string email=null)
        {
            if (email == null)
            {
                return firstName == FirstName && lastName == LastName;
            }

            return firstName == FirstName && lastName == LastName
                && email == EmailAddress;
        }

        public virtual string GetPassengerType()
        {
            return "I am a passenger";
        }

        public void GetAge(DateTime birthDate, ref int calculatedAge)
        {
            calculatedAge=DateTime.Now.Year-birthDate.Year;
            if(birthDate.Month>DateTime.Now.Month || 
                (birthDate.Month==DateTime.Now.Month && birthDate.Day>DateTime.Now.Day))
            {
                calculatedAge = calculatedAge - 1;
            }
        }
        public void GetAge(Passenger p)
        {
            p.Age = DateTime.Now.Year - p.BirthDate.Year;
            if (p.BirthDate.Month > DateTime.Now.Month ||
                (p.BirthDate.Month == DateTime.Now.Month && p.BirthDate.Day > DateTime.Now.Day))
            {
                p.Age = p.Age - 1;
            }
        }
    }
}
