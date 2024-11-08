// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.Data;



//Console.WriteLine("Hello, World!");


//Plane plane = new Plane();
//plane.Capacity = 10;
//plane.ManufactureDate = new DateTime(2024,12,24);
//plane.MyPlaneType = PlaneType.Boing;
//plane.PlaneId = 2;

//Plane plane2 = new Plane(PlaneType.Airbus,12, new DateTime(2024, 12, 24));

//Plane plane3 = new Plane()
//{
//    Capacity = 10,
//    ManufactureDate = new DateTime(2024, 05, 10)
//};

//Passenger p1, p2,p3;
//p1 = new Passenger();
//p2= new Staff();
//p3= new Traveller();

////Console.WriteLine(p1.GetPassengerType());
////Console.WriteLine(p2.GetPassengerType());
////Console.WriteLine(p3.GetPassengerType());

//int cAge = 0;
//p1.GetAge(new DateTime(2000, 1, 1), ref cAge);
//Console.WriteLine(cAge);
//p1.BirthDate = new DateTime(2000, 1, 1);
//Console.WriteLine(p1.Age);
//p1.GetAge(p1);
//Console.WriteLine(p1.Age);


Plane plane3 = new Plane()
{
    Capacity = 10,
    ManufactureDate = new DateTime(2024, 05, 10)
};
Flight f = new Flight()
{
    Destination = "GAZA",
    Departure = "Tunis",
    FlightDate = new DateTime(2024, 10, 18),
    EffectiveArrival = new DateTime(2024, 10, 19),
    EstimateDuration = 12,
    MyPlane = plane3,
    //Comment = "flight to GAZA"
};

AMContext ctxt = new AMContext();

ctxt.Flights.Add(f);
ctxt.SaveChanges();
//Tp5 Q8

//Flight flightTest = new Flight()
//                    {
//                        Departure = "Tunis",
//                        Destination = "Algerie",
//                        EffectiveArrival = new DateTime(2023, 11, 11, 12, 0, 0),
//                        EstimateDuration = 60,
//                        FlightDate = new DateTime(2024, 11, 11, 12, 30, 0)
//                    };

//Passenger passengerTest = new Passenger()
//{
//    BirthDate = new DateTime(1998, 10, 13),
//    PassportNumber = "1234567",
//    EmailAddress = "taha@gmail.com",
//    MyFullName = new FullName()
//    {

//        FirstName = "Taha",
//        LastName = "Naat"
//    },
//    TelNumber = "27583936"
//};

//Reservation reservation = new Reservation()
//{
//    Price = 200,
//    Seat = "A24",
//    Vip = true,
//    MyPassenger = passengerTest,
//    MyFlight = flightTest
//};

//AMContext aMContext = new AMContext();
//aMContext.Add(flightTest);
//aMContext.Add(passengerTest);
//aMContext.Add(reservation);
//aMContext.SaveChanges();
//TP5 Q10

Plane planeq10 = new Plane()
{
    Capacity = 10,
    ManufactureDate = new DateTime(1998, 09, 01, 10, 30, 0),
    MyPlaneType = PlaneType.Airbus

};

Flight flightq10 = new Flight()
{
    Departure = "TUNIS",
    Destination = "GAZA",
    EffectiveArrival = new DateTime(2024, 12, 12, 12, 0, 0),
    EstimateDuration = 60,
    FlightDate = new DateTime(2024, 12, 12, 12, 30, 0),
    MyPlane = planeq10

};


AMContext amcontext = new AMContext();
amcontext.Add(flightq10);
amcontext.Add(planeq10);
amcontext.SaveChanges();
Console.WriteLine(flightq10);
Console.WriteLine(flightq10.MyPlane);

Flight flightq11 = amcontext.Find<Flight>(2);
Console.WriteLine(flightq11);
Console.WriteLine(flightq11.MyPlane);