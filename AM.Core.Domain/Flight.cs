using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Core.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }

       
        public int PlaneId { get; set; }

        [ForeignKey("PlaneId")]
        public Plane MyPlane { get; set; }

        
        [StringLength(100, ErrorMessage = "La destination ne doit pas dépasser 100 caractères.")]
        public string Destination { get; set; }

        [StringLength(100, ErrorMessage = "Le lieu de départ ne doit pas dépasser 100 caractères.")]
        public string Departure { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Flight Date")]
        public DateTime FlightDate { get; set; }

        public DateTime EffectiveArrival { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La durée estimée doit être positive.")]
        public int EstimateDuration { get; set; }

        public IList<Passenger> Passengers { get; set; }
        public string Comments { get; set; }
    }
}
