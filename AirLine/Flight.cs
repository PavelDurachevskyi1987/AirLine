using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    public enum Status
    {
        CheckIn,
        GateClosed,
        GateOpened,
        Arrived,
        DepartedAt,
        Unknown,
        Canseled,
        ExpectedAt,
        Delayed,
        InFlight
    }

    public class Flight
    {

        public DateTime Arrival { get; private set; }
        public DateTime Departure { get; private set; }
        public int FlightNumber { get; private set; }
        public string CityArrival { get; private set; }
        public string CityDeparture { get; private set; }
        public int Terminal { get; private set; }
        public Status Status { get; private set; }
        public FlightTicket[] FlightTicket { get; private set; }
        public Passenger[] Passengers { get; private set; }

        public Flight() { }

        public Flight(DateTime arrival, DateTime departure, int flightNumber,
                string cityArrival, string cityDeparture, int terminal,
                Status status, FlightTicket[] flightTicket, params Passenger[] passengers)
        {
            Arrival = arrival;
            Departure = departure;
            FlightNumber = flightNumber;
            CityArrival = cityArrival;
            CityDeparture = cityDeparture;
            Terminal = terminal;
            Status = status;
            FlightTicket = flightTicket;
            Passengers = passengers;
        }

        public void PrintPassengers()
        {
            for (int i = 0; i < Passengers.Length; i++)
            {
                if (Passengers[i] != null)
                {
                    Console.WriteLine(Passengers[i].ToString());
                }
            }
        }

        public static Flight InputFlight()
        {
            Flight flight = new Flight();
            Console.Clear();
            Console.WriteLine("Enter value of date and time arrival(dd/mm/yyyy hh:mm:ss)");
            flight.Arrival = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of date and time departure(dd/mm/yyyy hh:mm:ss)");
            flight.Departure = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of Flight number:");
            flight.FlightNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city of arrival:");
            flight.CityArrival = Console.ReadLine();
            Console.WriteLine("Enter city of departure:");
            flight.CityDeparture = Console.ReadLine();
            Console.WriteLine("Enter value of terminal:");
            flight.Terminal = int.Parse(Console.ReadLine());
            Console.WriteLine(@"Select a flight status:
1.CheckIn,
2.GateClosed,
3.GateOpened,
4.Arrived,
5.DepartedAt,
6.Unknown,
7.Canseled,
8.ExpectedAt,
9.Delayed,
10.InFlight");
            int status = int.Parse(Console.ReadLine());
            switch (status)
            {
                case 1:
                    flight.Status = Status.CheckIn;
                    break;
                case 2:
                    flight.Status = Status.GateClosed;
                    break;
                case 3:
                    flight.Status = Status.GateOpened;
                    break;
                case 4:
                    flight.Status = Status.Arrived;
                    break;
                case 5:
                    flight.Status = Status.DepartedAt;
                    break;
                case 6:
                    flight.Status = Status.Unknown;
                    break;
                case 7:
                    flight.Status = Status.Canseled;
                    break;
                case 8:
                    flight.Status = Status.ExpectedAt;
                    break;
                case 9:
                    flight.Status = Status.Delayed;
                    break;
                case 10:
                    flight.Status = Status.InFlight;
                    break;
                default:
                    Console.WriteLine("You entered incorrect data !");
                    Console.ReadLine();
                    break;
            }
            Console.WriteLine($"Enter value of price for: {FlightClass.Business}");
            float business = float.Parse(Console.ReadLine());
            Console.WriteLine($"Enter value of price for: {FlightClass.Ecocnomy}");
            float economy = float.Parse(Console.ReadLine());
            Passenger[] pass = new Passenger[20];
            flight = new Flight(flight.Arrival, flight.Departure, flight.FlightNumber, flight.CityArrival,
                                flight.CityDeparture, flight.Terminal, flight.Status,
                     new FlightTicket[] { new FlightTicket (FlightClass.Business, business),
                                          new FlightTicket (FlightClass.Ecocnomy, economy)}, pass);
            return flight;
        }

        public void IputEdit(Flight[] flight, int position)
        {
            {
                Console.WriteLine("Enter value of date and time arrival(dd/mm/yyyy hh:mm:ss)");
                flight[position].Arrival = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter value of date and time departure(dd/mm/yyyy hh:mm:ss)");
                flight[position].Departure = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter value of Flight number:");
                flight[position].FlightNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter city of arrival:");
                flight[position].CityArrival = Console.ReadLine();
                Console.WriteLine("Enter city of departure:");
                flight[position].CityDeparture = Console.ReadLine();
                Console.WriteLine("Enter value of terminal:");
                flight[position].Terminal = int.Parse(Console.ReadLine());
                Console.WriteLine(@"Select a flight status:
1.CheckIn,
2.GateClosed,
3.GateOpened,
4.Arrived,
5.DepartedAt,
6.Unknown,
7.Canseled,
8.ExpectedAt,
9.Delayed,
10.InFlight");
                int status = int.Parse(Console.ReadLine());
                switch (status)
                {
                    case 1:
                        flight[position].Status = Status.CheckIn;
                        break;
                    case 2:
                        flight[position].Status = Status.GateClosed;
                        break;
                    case 3:
                        flight[position].Status = Status.GateOpened;
                        break;
                    case 4:
                        flight[position].Status = Status.Arrived;
                        break;
                    case 5:
                        flight[position].Status = Status.DepartedAt;
                        break;
                    case 6:
                        flight[position].Status = Status.Unknown;
                        break;
                    case 7:
                        flight[position].Status = Status.Canseled;
                        break;
                    case 8:
                        flight[position].Status = Status.ExpectedAt;
                        break;
                    case 9:
                        flight[position].Status = Status.Delayed;
                        break;
                    case 10:
                        flight[position].Status = Status.InFlight;
                        break;
                    default:
                        Console.WriteLine("You entered incorrect data !");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine($"Enter value of price for: {FlightClass.Business}");
                float business = float.Parse(Console.ReadLine());
                Console.WriteLine($"Enter value of price for: {FlightClass.Ecocnomy}");
                float economy = float.Parse(Console.ReadLine());
                FlightTicket[] ticket = new FlightTicket[]
                  {
                            new FlightTicket (FlightClass.Business, business ),
                            new FlightTicket (FlightClass.Ecocnomy, economy )
                  };
                for (int i = 0; i < flight.Length; i++)
                {
                    if (i == position)
                        flight[i] = flight[position];
                    if (flight[position].FlightTicket != ticket)
                    {
                        for (int j = 0; j < flight[position].FlightTicket.Length; j++)
                        {
                            flight[position].FlightTicket = ticket;
                        }
                    }
                }
            }
        }

        public void SearchPassenger(Flight[] flights, int positionAdd)
        {
            int count = 0;
            for (int i = 0; i < flights[positionAdd].Passengers.Length; i++)
            {
                if (flights[positionAdd].Passengers[i] != null)
                    count++;
            }
            flights[positionAdd].Passengers[count] = Passenger.InputAdd();
        }

        public override string ToString()
        {
            string mySring = new string('*', 70) + "\n" +
                 @"Arrival: " + Arrival + "\nDeparture: " + Departure + "\nFlightNumber: " + FlightNumber +
                "\nCityArrival: " + CityArrival + "\nCityDeparture: " + CityDeparture +
                "\nTerminal: " + Terminal + "\nStatus: " + Status + "\n" + new string('*', 70);
            return mySring;
        }

        public bool SearchByFirstName(Flight[] flight, string firstName, bool search, int count)
        {
            for (int i = 0; i < Passengers.Length; i++)
            {
                if (Passengers[i] != null)
                {
                    if (Passengers[i].FirstName == firstName)
                    {
                        Console.WriteLine(flight[count].ToString());
                        Console.WriteLine(Passengers[i].ToString());
                        search = false;
                    }
                }
            }
            return search;
        }

        public bool SearchByLastName(Flight[] flight, string lastName, bool search, int count)
        {
            for (int i = 0; i < Passengers.Length; i++)
            {
                if (Passengers[i] != null)
                {
                    if (Passengers[i].LastName == lastName)
                    {
                        Console.WriteLine(flight[count].ToString());
                        Console.WriteLine(Passengers[i].ToString());
                        search = false;
                    }
                }
            }
            return search;
        }

        public bool SearchByPassport(Flight[] flight, int numberPassport, bool search, int count)
        {
            for (int i = 0; i < Passengers.Length; i++)
            {
                if (Passengers[i] != null)
                {
                    if (Passengers[i].Passport == numberPassport)
                    {
                        Console.WriteLine(flight[count].ToString());
                        Console.WriteLine(Passengers[i].ToString());
                        search = false;
                    }
                }
            }
            return search;
        }

        public bool SearchPrice(Flight[] flight, float minPrice, float maxPrice, bool search, int count)
        {
            for (int i = 0; i < FlightTicket.Length; i++)
            {
                if (FlightTicket != null)
                {
                    if (FlightTicket[i].Price >= minPrice
                    && FlightTicket[i].Price <= maxPrice)
                    {
                        if (FlightTicket[i].FlightClass == FlightClass.Ecocnomy)
                        {
                            Console.WriteLine(flight[count].ToString());
                            Console.WriteLine($"Price for {FlightTicket[i].FlightClass} class: {FlightTicket[i].Price}$");
                            Console.WriteLine(new string('_', 30));
                            search = false;
                        }
                    }
                }
            }
            return search;
        }
    }
}