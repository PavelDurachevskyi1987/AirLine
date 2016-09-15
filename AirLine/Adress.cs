using System;

namespace AirLine
{
    public class Adress
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public int NumberBuilding { get; private set; }

        public Adress(string country, string city, 
            string street, int numberBuilding)
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