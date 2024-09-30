// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;


Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.Capacity = 10;
plane.ManufactureDate = new DateTime(2024,12,24);
plane.MyPlaneType = PlaneType.Boing;
plane.PlaneId = 2;
Plane plane2 = new Plane(PlaneType.Airbus,12, new DateTime(2024, 12, 24));
Plane plane3 = new Plane()
{
    Capacity = 10,
    ManufactureDate = new DateTime(2024, 05, 10)
};
Passenger p1, p2, p3;
p1  = new Passenger();
p2 = new Staff();
p3 = new Traveller();
/*Console.WriteLine(p1.GetPassangerType());
Console.WriteLine(p2.GetPassangerType());
Console.WriteLine(p3.GetPassangerType());*/
int cAge = 0;
p1.GetAge(new DateTime(2000,1 ,1), ref cAge);
Console.WriteLine(cAge);
p1.BirthDate = new DateTime(2000 , 1 , 1);
Console.WriteLine(cAge);