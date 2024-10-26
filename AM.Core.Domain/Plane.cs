using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Plane
    {
        [Range(0,int.MaxValue,ErrorMessage ="positive int")]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType MyPlaneType { get; set; }
        public IList<Flight> Flights { get; set; }
        public Plane() { }
        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            MyPlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }
       public override string ToString()
        {
            return  "Capacity:" + Capacity 
                + "ManufactureDate:" + ManufactureDate 
                + "MyPlaneType:" + MyPlaneType 
                + "PlaneId:"+ PlaneId;
        }
    }
}
