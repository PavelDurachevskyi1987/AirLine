using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    public enum Sex
    {
        Male,
        Famale
    }

    public class Passenger
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Nationality { get; private set; }
        public int Passport { get; private set; }
        public DateTime Birthday { get; private set; }
        public Sex Sex { get; private set; }
        public FlightTicket FlightTicket { get; private set; }

        public Passenger() { }

        public Passenger(string firstName, string lastName, string nationality,
                         int passport, DateTime birthday, Sex sex, FlightTicket flightTicket)
        {
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            Passport = passport;
            Birthday = birthday.Date;
            Sex = sex;
            FlightTicket = flightTicket;
        }

        public void Delete(Passenger[] passenger, int countPassenger)
        {
            {
                Console.Clear();
                for (int i = countPassenger; i < passenger.Length - 1; i++)
                {
                    passenger[i] = passenger[i + 1];
                }
            }
        }

        public static Passenger InputAdd()
        {
            Console.Clear();
            Passenger passenger = new Passenger();
            Console.WriteLine("Enter First Name:");
            passenger.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            passenger.LastName = Console.ReadLine();
            Console.WriteLine("Enter nationality:");
            passenger.Nationality = Console.ReadLine();
            Console.WriteLine("Enter Passport:");
            passenger.Passport = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of birth(dd/mm/yyyy)");
            passenger.Birthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(@"Select a sex:
1.Male
2.Famale");
            int sex = int.Parse(Console.ReadLine());
            if (sex == 1)
                passenger.Sex = Sex.Male;
            else if (sex == 2)
                passenger.Sex = Sex.Famale;
            else
            {
                Console.WriteLine("You entered incorrect data !");
                Console.ReadLine();
            }
            Console.WriteLine("Enter the price of the flight :");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine(@"Select a flight class: 
1.Business
2.Economy");
            int flightClass = int.Parse(Console.ReadLine());
            if (flightClass == 1)
                passenger.FlightTicket = new FlightTicket(FlightClass.Business, price);
            else if (flightClass == 2)
                passenger.FlightTicket = new FlightTicket(FlightClass.Ecocnomy, price);
            else
            {
                Console.WriteLine("You entered incorrect data !");
                Console.ReadLine();
            }
            passenger = new Passenger(passenger.FirstName, passenger.LastName, passenger.Nationality,
                        passenger.Passport, passenger.Birthday, passenger.Sex, passenger.FlightTicket);
            return passenger;
        }

        public void Edit(Passenger[] passenger, int countPassenger)
        {
            Console.Clear();
            Console.WriteLine("Enter First Name:");
            passenger[countPassenger].FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            passenger[countPassenger].LastName = Console.ReadLine();
            Console.WriteLine("Enter nationality:");
            passenger[countPassenger].Nationality = Console.ReadLine();
            Console.WriteLine("Enter Passport:");
            passenger[countPassenger].Passport = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of birth(dd/mm/yyyy)");
            passenger[countPassenger].Birthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(@"Select a sex:
1.Male
2.Famale");
            int sex = int.Parse(Console.ReadLine());
            if (sex == 1)
                passenger[countPassenger].Sex = Sex.Male;
            else if (sex == 2)
                passenger[countPassenger].Sex = Sex.Famale;
            else
            {
                Console.WriteLine("You entered incorrect data !");
                Console.ReadLine();
            }
            Console.WriteLine("Enter the price of the flight :");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine(@"Select a flight class: 
1.Business
2.Economy");
            int flightClass = int.Parse(Console.ReadLine());
            if (flightClass == 1)
                FlightTicket = new FlightTicket(FlightClass.Business, price);
            else if (flightClass == 2)
                FlightTicket = new FlightTicket(FlightClass.Ecocnomy, price);
            else
            {
                Console.WriteLine("You entered incorrect data !");
                Console.ReadLine();
            }
            for (int i = 0; i < passenger.Length; i++)
            {
                if (i == countPassenger)
                    passenger[i] = passenger[countPassenger];
            }
        }

        public override string ToString()
        {
            string myString = @"FirstName: " + FirstName + "\nLastName: " + LastName + "\nNationality: " + Nationality +
                "\nPassport: " + Passport + "\nBirthday: " + Birthday.Date.ToString("dd.MM.yyyy") + "\nSex: " + Sex +
                "\nFlight class: " + FlightTicket.FlightClass + "\nPrice: " + FlightTicket.Price +
                "\n" + new string('_', 30);
            return myString;
        }
    }
}
