// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.Data;
/*Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.Capacity = 10;
plane.ManufactureDate = new DateTime(2024, 12, 24);
plane.MyPlaneType = PlaneType.Boing;
plane.PlaneId = 2;
Plane plane2 = new Plane(PlaneType.Airbus, 12, new DateTime(2024, 12, 24));
Passenger passenger = new Passenger();
Passenger staff = new Staff();
Passenger traveller = new Traveller();
Passenger anotherPassenger = new Passenger { BirthDate = new DateTime(1985, 10, 25) };
Passenger passengee = new Passenger { BirthDate = new DateTime(1985, 10, 25) };
Console.WriteLine(passenger.GetPassengerType());
Console.WriteLine(staff.GetPassengerType());
Console.WriteLine(traveller.GetPassengerType());
int ageValue = 0;
passenger.GetAge(passenger.BirthDate, ref ageValue);
Console.WriteLine($"Passage par référence : âge calculé = {ageValue}");
passenger.GetAge(anotherPassenger)
Console.WriteLine($"Passage d'un objet Passenger : âge = {anotherPassenger.age}");*/
Plane plane = new Plane();

Flight f = new Flight()
{
    Destination = "Paris",
    Departure = "New York",
    FlightDate = DateTime.Now.AddHours(2),
    EffectiveArrival = DateTime.Now,
    MyPlane = plane,
    EstimateDuration = 6,
    Comments = "Vol sans escale",


};

AMContext ctxt = new AMContext();
ctxt.Flights.Add(f);

ctxt.SaveChanges();