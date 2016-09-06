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
    public class Flight : IFlightSearch
    {
        
        public DateTime Arrival { get; private set; }
        public DateTime Departure { get; private set; }
        public int FlightNumber { get; private set; }
        public string CityArrival { get; private set; }
        public string CityDeparture { get; private set; }
        public int Terminal { get; private set; }
        public Status Status { get; private set; }
        public FlightTicket[] FlightTicket { get; private set; }
        public Passenger[] Passenger { get; private set; }

        public Flight() { }

        public Flight(DateTime arrival, DateTime departure, int flightNumber,
                string cityArrival, string cityDeparture, int terminal,
                Status status, FlightTicket[] flightTicket,params Passenger[] passenger)
        {
            Arrival = arrival;
            Departure = departure;
            FlightNumber = flightNumber;
            CityArrival = cityArrival;
            CityDeparture = cityDeparture;
            Terminal = terminal;
            Status = status;
            FlightTicket = flightTicket;
            Passenger = passenger;
        }
        Adress adress = new Adress();

        public void Delete(AirLineInfo[] mass)
        {
            Console.Clear();
            adress.PrintAdress();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                    Console.WriteLine(mass[i].Flight.ToString()); 
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter the flight number to Delete: ");
            Console.ResetColor();
            int numberDelete = int.Parse(Console.ReadLine());
            int positionDelete = -1;
            Console.Clear();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    if (numberDelete == mass[i].Flight.FlightNumber)
                    {
                        positionDelete = i;
                    }
                }
            }
            for (int i = positionDelete; i < mass.Length - 1; i++)
            {
                mass[i] = mass[i + 1];
            }
        }
        public void Print(AirLineInfo[] mass)
        {
            adress.PrintAdress();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                    Console.WriteLine(mass[i].Flight.ToString());
            }
            Console.ReadLine();
        }

        public void PrintWithPrices(AirLineInfo[] mass)
        {
            adress.PrintAdress();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                { 
                    Console.WriteLine(mass[i].Flight.ToString());      
                    for (int j = 0; j < mass[i].Flight.FlightTicket.Length; j++)
                    {
                        Console.WriteLine($"Price for {mass[i].Flight.FlightTicket[j].FlightClass} class: {mass[i].Flight.FlightTicket[j].Price}$");
                    }
                    Console.WriteLine(new string('_', 30));
                }
            }
            Console.ReadLine();
        }
        public void SearchCityArrival(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter city arrival:");
            string cityArrival = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    if (mass[i].Flight.CityArrival == cityArrival)
                    {
                        Console.WriteLine(mass[i].Flight.ToString());
                        count = false;
                    }
                }
            }
            if (count)
            Helper.NothingFound();
            Console.ReadLine();

        }

        public void SearchCityDeparture(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter city departure: ");
            string cityDeparture = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    if (mass[i].Flight.CityDeparture == cityDeparture)
                    {
                        Console.WriteLine(mass[i].Flight.ToString());
                        count = false;
                    }
                }
            }
              if(count)
              Helper.NothingFound();
              Console.ReadLine();
        }
        public void SearchNumber(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter flight number: ");
            int flightNumber = int.Parse(Console.ReadLine());
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    if (mass[i].Flight.FlightNumber == flightNumber)
                    {
                        Console.WriteLine(mass[i].Flight.ToString());
                        count = false;
                    }
                }
            }
            if (count)
            Helper.NothingFound();
            Console.ReadLine();
        }
        public void SearchPrice(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter min price of fligth for economy class: ");
            float minPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter max price of fligthfor for economy class: ");
            float maxPrice = float.Parse(Console.ReadLine());
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
                {
                if (mass[i] != null)
                {
                    for (int j = 0; j < mass[i].Flight.FlightTicket.Length; j++)
                    {
                        if (mass[i].Flight != null)
                        {
                            if (mass[i].Flight.FlightTicket[j].Price >= minPrice
                            && mass[i].Flight.FlightTicket[j].Price <= maxPrice)
                            {
                                if (mass[i].Flight.FlightTicket[j].FlightClass == FlightClass.Ecocnomy)
                                    Console.WriteLine(mass[i].Flight.ToString());
                                count = false;
                            }
                        }
                    }
                }
         }
            if (count)
            Helper.NothingFound();
            Console.ReadLine();
        }
        public void Add(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter value of date and time arrival(dd/mm/yyyy hh:mm:ss)");
            Arrival = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of date and time departure(dd/mm/yyyy hh:mm:ss)");
            Departure = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of Flight number:");
            FlightNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city of arrival:");
            CityArrival = Console.ReadLine();
            Console.WriteLine("Enter city of departure:");
            CityDeparture = Console.ReadLine();
            Console.WriteLine("Enter value of terminal:");
            Terminal = int.Parse(Console.ReadLine());
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
                    Status = Status.CheckIn;
                    break;
                case 2:
                    Status = Status.GateClosed;
                    break;
                case 3:
                    Status = Status.GateOpened;
                    break;
                case 4:
                    Status = Status.Arrived;
                    break;
                case 5:
                    Status = Status.DepartedAt;
                    break;
                case 6:
                    Status = Status.Unknown;
                    break;
                case 7:
                    Status = Status.Canseled;
                    break;
                case 8:
                    Status = Status.ExpectedAt;
                    break;
                case 9:
                    Status = Status.Delayed;
                    break;
                case 10:
                    Status = Status.InFlight;
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
            int count = 0;
            for (int i = 0; i < mass.Length; i++)
            {
             if (mass[i] != null)
                 count++;
            }
            Passenger[] pass = new Passenger[20];           
            int position = count + 1;
            mass[position] = new AirLineInfo(new Adress(), new Flight(Arrival, Departure, FlightNumber, CityArrival, CityDeparture, Terminal, Status,
                             new FlightTicket[] { new FlightTicket (FlightClass.Business, business),
                                              new FlightTicket (FlightClass.Ecocnomy, economy) }, pass));
        }
        public void Edit(AirLineInfo[] mass)
        {
            {
                Console.Clear();
                adress.PrintAdress();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        Console.WriteLine(mass[i].Flight.ToString()); 
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter the flight number to edit: ");
                Console.ResetColor();
                int number = int.Parse(Console.ReadLine());
                int position = -1;
                Console.Clear();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        if (number == mass[i].Flight.FlightNumber)
                        {
                            position = i;
                        }
                    }
                }
                Console.WriteLine("Enter value of date and time arrival(dd/mm/yyyy hh:mm:ss)");
                mass[position].Flight.Arrival = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter value of date and time departure(dd/mm/yyyy hh:mm:ss)");
                mass[position].Flight.Departure = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter value of Flight number:");
                mass[position].Flight.FlightNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter city of arrival:");
                mass[position].Flight.CityArrival = Console.ReadLine();
                Console.WriteLine("Enter city of departure:");
                mass[position].Flight.CityDeparture = Console.ReadLine();
                Console.WriteLine("Enter value of terminal:");
                mass[position].Flight.Terminal = int.Parse(Console.ReadLine());
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
                        mass[position].Flight.Status = Status.CheckIn;
                        break;
                    case 2:
                        mass[position].Flight.Status = Status.GateClosed;
                        break;
                    case 3:
                        mass[position].Flight.Status = Status.GateOpened;
                        break;
                    case 4:
                        mass[position].Flight.Status = Status.Arrived;
                        break;
                    case 5:
                        mass[position].Flight.Status = Status.DepartedAt;
                        break;
                    case 6:
                        mass[position].Flight.Status = Status.Unknown;
                        break;
                    case 7:
                        mass[position].Flight.Status = Status.Canseled;
                        break;
                    case 8:
                        mass[position].Flight.Status = Status.ExpectedAt;
                        break;
                    case 9:
                        mass[position].Flight.Status = Status.Delayed;
                        break;
                    case 10:
                        mass[position].Flight.Status = Status.InFlight;
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
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == position)
                        mass[i].Flight = mass[position].Flight;
                    if (mass[position].Flight.FlightTicket != ticket)
                    {
                        for (int j = 0; j < mass[position].Flight.FlightTicket.Length; j++)
                        {
                            mass[position].Flight.FlightTicket = ticket;
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            string mySring = new string('*', 70) + "\n" +
                 @"Arrival: " + Arrival + "\nDeparture: " + Departure + "\nFlightNumber: " + FlightNumber +
                "\nCityArrival: " + CityArrival + "\nCityDeparture: " + CityDeparture +
                "\nTerminal: " + Terminal + "\nStatus: " + Status + "\n" + new string('*', 70);
            return mySring;
        }      
    }
}