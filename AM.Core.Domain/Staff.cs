using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain
{
    public class Staff : Passenger
    {
        [DataType(DataType.Date)]
        [Display(Name = "Employment Date")]
        public DateTime EmploymentDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Function cannot exceed 100 characters.")]
        public string Function { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   $"EmploymentDate: {EmploymentDate.ToShortDateString()}, " +
                   $"Function: {Function}, " +
                   $"Salary: {Salary}";
        }

        public override string GetPassengerType()
        {
            return "I am a passenger and a staff member.";
        }
    }
}
