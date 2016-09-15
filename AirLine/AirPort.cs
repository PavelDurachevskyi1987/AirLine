using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    public class AirPort : ISearch
    {
        public Adress Adress { get; private set; }
        public Flight[] Flights { get; private set; }

        public AirPort() { }

        public AirPort(Adress adress, Flight[] flights)
        {
            Adress = adress;
            Flights = flights;
        }

        public void AddFlight()
        {
            int count = 0;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                    count++;
            }
            Flights[count] = Flight.InputFlight();
        }

        public void EditFlight()
        {
            Console.Clear();
            Print();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter the flight number to edit: ");
            Console.ResetColor();
            int number = int.Parse(Console.ReadLine());
            int position = -1;
            Console.Clear();
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    if (number == Flights[i].FlightNumber)
                    {
                        position = i;
                    }
                }
            }
            Flights[position].IputEdit(Flights, position);
        }

        public void DeleteFlight()
        {
            Console.Clear();
            Print();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter the flight number to Delete: ");
            Console.ResetColor();
            int numberDelete = int.Parse(Console.ReadLine());
            int positionDelete = -1;
            Console.Clear();
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    if (numberDelete == Flights[i].FlightNumber)
                    {
                        positionDelete = i;
                    }
                }
            }
            for (int i = positionDelete; i < Flights.Length - 1; i++)
            {
                Flights[i] = Flights[i + 1];
            }
        }

        public void Print()
        {
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                    Console.WriteLine(Flights[i].ToString());
            }
        }

        public void PrintWithPrices()
        {
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    Console.WriteLine(Flights[i].ToString());
                    for (int j = 0; j < Flights[i].FlightTicket.Length; j++)
                    {
                        Console.WriteLine($"Price for {Flights[i].FlightTicket[j].FlightClass} class: {Flights[i].FlightTicket[j].Price}$");
                    }
                    Console.WriteLine(new string('_', 30));
                }
            }
        }

        public void PrintFlightWithPassengers()
        {
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    Console.WriteLine(Flights[i].ToString());
                    Flights[i].PrintPassengers();
                }
            }
        }

        public void AddPassenger()
        {
            Console.Clear();
            PrintFlightWithPassengers();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the flight number to add passenger");
            Console.ResetColor();
            int numberAdd = int.Parse(Console.ReadLine());
            int positionAdd = -1;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    if (numberAdd == Flights[i].FlightNumber)
                    {
                        positionAdd = i;
                    }
                }
            }
            Flights[positionAdd].SearchPassenger(Flights, positionAdd);
        }

        public void EditPassenger()
        {
            Console.Clear();
            PrintFlightWithPassengers();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the passport number to edit passenger");
            Console.ResetColor();
            int numberPassport = int.Parse(Console.ReadLine());
            int countPassenger = 0;
            int countFlight = 0;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    for (int j = 0; j < Flights[i].Passengers.Length; j++)
                    {
                        if (Flights[i].Passengers[j] != null)
                        {
                            if (numberPassport == Flights[i].Passengers[j].Passport)
                            {
                                countFlight = i;
                                countPassenger = j;
                            }
                        }
                    }
                }
            }
            Flights[countFlight].Passengers[countPassenger]
            .Edit(Flights[countFlight].Passengers, countPassenger);
        }

        public void DeletePassenger()
        {
            Console.Clear();
            PrintFlightWithPassengers();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the passport number to delete passenger");
            Console.ResetColor();
            int numberPassport = int.Parse(Console.ReadLine());
            int countPassenger = 0;
            int countFlight = 0;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    for (int j = 0; j < Flights[i].Passengers.Length; j++)
                    {
                        if (Flights[i].Passengers[j] != null)
                        {
                            if (numberPassport == Flights[i].Passengers[j].Passport)
                            {
                                countFlight = i;
                                countPassenger = j;
                            }
                        }
                    }
                }
            }
            Flights[countFlight].Passengers[countPassenger]
            .Delete(Flights[countFlight].Passengers, countPassenger);
        }

        public void SearchByFirstName()
        {
            Console.Clear();
            Console.WriteLine("Enter firstname of passenger: ");
            string firstName = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    for (int j = 0; j < Flights[i].Passengers.Length; j++)
                    {
                        if (Flights[i].Passengers[j] != null)
                        {
                            if (Flights[i].Passengers[j].FirstName == firstName)
                            {
                                Console.WriteLine(Flights[i].ToString());
                                Console.WriteLine(Flights[i].Passengers[j].ToString());
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

        public void SearchByLastName()
        {
            Console.Clear();
            Console.WriteLine("Enter lastdName of passenger: ");
            string lastName = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    for (int j = 0; j < Flights[i].Passengers.Length; j++)
                    {
                        if (Flights[i].Passengers[j] != null)
                        {
                            if (Flights[i].Passengers[j].LastName == lastName)
                            {
                                Console.WriteLine(Flights[i].ToString());
                                Console.WriteLine(Flights[i].Passengers[j].ToString());
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

        public void SearchByPassport()
        {
            Console.Clear();
            Console.WriteLine("Enter the passport number of passenger: ");
            int numberPassport = int.Parse(Console.ReadLine());
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    for (int j = 0; j < Flights[i].Passengers.Length; j++)
                    {
                        if (Flights[i].Passengers[j] != null)
                        {
                            if (Flights[i].Passengers[j].Passport == numberPassport)
                            {
                                Console.WriteLine(Flights[i].ToString());
                                Console.WriteLine(Flights[i].Passengers[j].ToString());
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

        public void SearchCityArrival()
        {
            Console.Clear();
            Console.WriteLine("Enter city arrival:");
            string cityArrival = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    if (Flights[i].CityArrival == cityArrival)
                    {
                        Console.WriteLine(Flights[i].ToString());
                        count = false;
                    }
                }
            }
            if (count)
                Helper.NothingFound();
            Console.ReadLine();
        }

        public void SearchCityDeparture()
        {
            Console.Clear();
            Console.WriteLine("Enter city departure: ");
            string cityDeparture = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    if (Flights[i].CityDeparture == cityDeparture)
                    {
                        Console.WriteLine(Flights[i].ToString());
                        count = false;
                    }
                }
            }
            if (count)
                Helper.NothingFound();
            Console.ReadLine();
        }

        public void SearchPrice()
        {
            Console.Clear();
            Console.WriteLine("Enter min price of fligth for economy class: ");
            float minPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter max price of fligthfor for economy class: ");
            float maxPrice = float.Parse(Console.ReadLine());
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    for (int j = 0; j < Flights[i].FlightTicket.Length; j++)
                    {
                        if (Flights[i].FlightTicket != null)
                        {
                            if (Flights[i].FlightTicket[j].Price >= minPrice
                            && Flights[i].FlightTicket[j].Price <= maxPrice)
                            {
                                if (Flights[i].FlightTicket[j].FlightClass == FlightClass.Ecocnomy)
                                {
                                    Console.WriteLine(Flights[i].ToString());
                                    Console.WriteLine($"Price for {Flights[i].FlightTicket[j].FlightClass} class: {Flights[i].FlightTicket[j].Price}$");
                                    Console.WriteLine(new string('_', 30));
                                    count = false;
                                }
                            }
                        }
                    }
                }
            }
            if (count)
                Helper.NothingFound();
            Console.ReadLine();
        }

        public void SearchNumberFLight()
        {
            Console.Clear();
            Console.WriteLine("Enter flight number: ");
            int flightNumber = int.Parse(Console.ReadLine());
            bool count = true;
            for (int i = 0; i < Flights.Length; i++)
            {
                if (Flights[i] != null)
                {
                    if (Flights[i].FlightNumber == flightNumber)
                    {
                        Console.WriteLine(Flights[i].ToString());
                        count = false;
                    }
                }
            }
            if (count)
                Helper.NothingFound();
            Console.ReadLine();
        }

        public AirPort FlightGeneration()
        {
            Passenger[] passengerFlightOne = new Passenger[20];
            passengerFlightOne[0] = new Passenger("Ignat", "Ignatenko", "UA", 070707, DateTime.Parse("13.11.1985"), Sex.Male, new FlightTicket(FlightClass.Business, 500));
            passengerFlightOne[1] = new Passenger("Egor", "Egorenko", "UA", 080808, DateTime.Parse("01.10.1977"), Sex.Male, new FlightTicket(FlightClass.Ecocnomy, 300));
            passengerFlightOne[2] = new Passenger("Tatyana", "Tatyanenko", "UA", 090909, DateTime.Parse("12.10.1987"), Sex.Famale, new FlightTicket(FlightClass.Ecocnomy, 300));

            Passenger[] passengerFlightTwo = new Passenger[20];
            passengerFlightTwo[0] = new Passenger("Nikita", "Nikotenko", "UA", 020202, DateTime.Parse("10.01.1986"), Sex.Male, new FlightTicket(FlightClass.Business, 400));
            passengerFlightTwo[1] = new Passenger("Maxim", "Maximenko", "UA", 030303, DateTime.Parse("11.11.1983"), Sex.Male, new FlightTicket(FlightClass.Ecocnomy, 200));
            passengerFlightTwo[2] = new Passenger("Galya", "Galenko", "UA", 040404, DateTime.Parse("01.01.1991"), Sex.Famale, new FlightTicket(FlightClass.Ecocnomy, 200));

            Flight[] flight = new Flight[10];
            flight[0] = new Flight(DateTime.Parse("01.10.2016 08:10:00"), DateTime.Parse("01.10.2016 05:15:00"), 1, "Kharkov", "Istanbul", 01, Status.ExpectedAt,
            new FlightTicket[] { new FlightTicket(FlightClass.Business, 500), new FlightTicket(FlightClass.Ecocnomy, 300) }, passengerFlightOne);

            flight[1] = new Flight(DateTime.Parse("01.10.2016 10:10:00"), DateTime.Parse("01.10.2016 07:15:00"), 2, "Kharkov", "Antalya", 02, Status.Delayed,
            new FlightTicket[] { new FlightTicket(FlightClass.Business, 400), new FlightTicket(FlightClass.Ecocnomy, 200) }, passengerFlightTwo);

            AirPort airport = new AirPort(new Adress("Ukraine", "Kharkov", "Romashkina", 1), flight);
            return airport;
        }

        public void Run()
        {
            AirPort airPort = FlightGeneration();
            int menu;
            do
            {
                Console.Clear();
                airPort.Adress.PrintAdress();
                Console.WriteLine(@"Welcom to Airport.
Select an action:
1.Information about flight
2.Information about flight with price
3.Information about passengers in fligths
4.Edit information about flights
5.Edit information about passengers
6.Search
0. Exit");
                menu = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        airPort.Print();
                        Console.ReadLine();
                        break;
                    case 2:
                        airPort.PrintWithPrices();
                        Console.ReadLine();
                        break;
                    case 3:
                        airPort.PrintFlightWithPassengers();
                        Console.ReadLine();
                        break;
                    case 4:
                        int editFlight;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(@"1.Add flight
2.Edit flight
3.Delete flight
0.Back");
                            editFlight = int.Parse(Console.ReadLine());
                            Console.Clear();
                            switch (editFlight)
                            {
                                case 1:
                                    airPort.AddFlight();
                                    break;
                                case 2:
                                    airPort.EditFlight();
                                    break;
                                case 3:
                                    airPort.DeleteFlight();
                                    break;
                            }
                        } while (editFlight != 0);
                        break;
                    case 5:
                        int editPassenger;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(@"1.Add passengers
2.Edit passengers
3.Delete passengers
0.Back");
                            editPassenger = int.Parse(Console.ReadLine());
                            switch (editPassenger)
                            {
                                case 1:
                                    airPort.AddPassenger();
                                    break;
                                case 2:
                                    airPort.EditPassenger();
                                    break;
                                case 3:
                                    airPort.DeletePassenger();
                                    break;
                            }
                        } while (editPassenger != 0);
                        break;
                    case 6:
                        int search;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(@"1.Search by city arrived
2.Search by city departure
3.Search by flight number
4.Search by firstname of passenger
5.Search by lastName of passenger
6.Search by passport number of passenger
7.Search by price of fligth for economy class
0.Back");
                            search = int.Parse(Console.ReadLine());
                            switch (search)
                            {
                                case 1:
                                    airPort.SearchCityArrival();
                                    break;
                                case 2:
                                    airPort.SearchCityDeparture();
                                    break;
                                case 3:
                                    airPort.SearchNumberFLight();
                                    break;
                                case 4:
                                    airPort.SearchByFirstName();
                                    break;
                                case 5:
                                    airPort.SearchByLastName();
                                    break;
                                case 6:
                                    airPort.SearchByPassport();
                                    break;
                                case 7:
                                    airPort.SearchPrice();
                                    break;
                            }
                        } while (search != 0);
                        break;
                }
            } while (menu != 0);
        }
    }
}



