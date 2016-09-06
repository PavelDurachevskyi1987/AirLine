using System;

namespace AirLine
{
    public class Adress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberBuilding { get; set; }

        public Adress(string country = "Ukraine", string city = "Kharkov", 
            string street = "Romashkina", int numberBuilding = 1)
        {
            Country = country;
            City = city;
            Street = street;
            NumberBuilding = numberBuilding;
        }
        public void PrintAdress()
        {
            Console.WriteLine($"Adress of Airport: {Country}, {City}, {Street}, {NumberBuilding} \n {new string('_', 50)}");       
        }
    }
}