using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
       // public int PassengerId { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date format")]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }
        [Key]
        [Length(minimumLength:7,maximumLength:7,ErrorMessage ="taille exacte 7 caracters")]
        public string PassportNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long")]
        [MaxLength(25, ErrorMessage = "First Name must be no longer than 25 characters")]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        [Phone (ErrorMessage = "invalide phone number")]
        public string TelNumber { get; set; }
        //public IList<Flight> Flights { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
        public int Age { get; set; }

        public FullName MyFullName { get; set; }

        public override string ToString()
        {
            return "BirthDate:" + BirthDate + ";"
                + "PassportNumber:" + PassportNumber + ";"
                + "EmailAddress:" + EmailAddress + ";"
                + "FirstName:" + MyFullName.FirstName + ";"
                + "LastName:" + MyFullName.LastName + ";"
                + "TelNumber:" + TelNumber;
        }
        public bool CheckProfile(string lastName, string firstName)
        {
            if (lastName == MyFullName.LastName && firstName == MyFullName.FirstName)
                return true;
            return false;
        }

        //public bool CheckProfile(string firstName, string lastName ,string email)
        //{
        //    return firstName == FirstName && lastName == LastName
        //        && email == EmailAddress;
        //}
        public bool CheckProfile(string lastName, string firstName, string emailAdress = null)
        {
            if (emailAdress == null)
                return lastName == MyFullName.LastName && firstName == MyFullName.FirstName;
            else
                return lastName == MyFullName.LastName && firstName == MyFullName.FirstName && emailAdress == EmailAddress;
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
