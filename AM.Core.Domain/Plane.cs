using AM.Core.Domain;
using System.ComponentModel.DataAnnotations;

public class Plane
{
    public int PlaneId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive number.")]
    public int Capacity { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Manufacture Date")]
    public DateTime ManufactureDate { get; set; }

    public PlaneType MyPlaneType { get; set; }

    public IList<Flight> Flights { get; set; }

    // Constructors
    public Plane() { }

    public Plane(PlaneType pt, int capacity, DateTime date)
    {
        MyPlaneType = pt;
        Capacity = capacity;
        ManufactureDate = date;
    }

    public override string ToString()
    {
        return $"Capacity: {Capacity}, ManufactureDate: {ManufactureDate.ToShortDateString()}, " +
               $"MyPlaneType: {MyPlaneType}, PlaneId: {PlaneId}";
    }
}
