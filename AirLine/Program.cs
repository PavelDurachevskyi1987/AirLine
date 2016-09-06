using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    class Program
    {
        static void Main(string[] args)
        {
  
            AirLineInfo[] info = new AirLineInfo[10];

            Passenger[] passengerFlightOne = new Passenger[20];
            passengerFlightOne[0] = new Passenger("Ignat", "Ignatenko", "UA", 070707, DateTime.Parse("13.11.1985"), Sex.Male, new FlightTicket(FlightClass.Business, 500));
            passengerFlightOne[1] = new Passenger("Egor", "Egorenko", "UA", 080808, DateTime.Parse("01.10.1977"), Sex.Male, new FlightTicket(FlightClass.Ecocnomy, 300));
            passengerFlightOne[2] = new Passenger("Tatyana", "Tatyanenko", "UA", 090909, DateTime.Parse("12.10.1987"), Sex.Famale, new FlightTicket(FlightClass.Ecocnomy, 300));

            Passenger[] passengerFlightTwo = new Passenger[20];
            passengerFlightTwo[0] = new Passenger("Nikita", "Nikotenko", "UA", 020202, DateTime.Parse("10.01.1986"), Sex.Male, new FlightTicket(FlightClass.Business, 400));
            passengerFlightTwo[1] = new Passenger("Maxim", "Maximenko", "UA", 030303, DateTime.Parse("11.11.1983"), Sex.Male, new FlightTicket(FlightClass.Ecocnomy, 200));
            passengerFlightTwo[2] = new Passenger("Galya", "Galenko", "UA", 040404, DateTime.Parse("01.01.1991"), Sex.Famale, new FlightTicket(FlightClass.Ecocnomy, 200));

            info[0] = new AirLineInfo(new Adress(),
            new Flight(DateTime.Parse("01.10.2016 08:10:00"), DateTime.Parse("01.10.2016 05:15:00"), 1, "Kharkov", "Istanbul", 01, Status.ExpectedAt,
            new FlightTicket[] { new FlightTicket(FlightClass.Business, 500), new FlightTicket(FlightClass.Ecocnomy, 300) }, passengerFlightOne));

            info[1] = new AirLineInfo(new Adress(),
            new Flight(DateTime.Parse("01.10.2016 10:10:00"), DateTime.Parse("01.10.2016 07:15:00"), 2, "Kharkov", "Antalya", 02, Status.Delayed,
            new FlightTicket[] { new FlightTicket(FlightClass.Business, 400), new FlightTicket(FlightClass.Ecocnomy, 200) }, passengerFlightTwo));

            int menu;
            Flight f = new Flight();
            Passenger p = new Passenger();
            do
            {                
                Console.Clear();
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
                        f.Print(info);
                        break;
                    case 2:
                       f.PrintWithPrices(info);
                        break;
                    case 3:
                        p.Print(info);
                break;
                    case 4:
                        Console.WriteLine(@"1.Add flight
2.Edit flight
3.Delete flight
0.Back");
                        int editFlight = int.Parse(Console.ReadLine());
                        if (editFlight == 1)
                            f.Add(info);
                        else if (editFlight == 2)
                            f.Edit(info);
                        else if (editFlight == 3)
                            f.Delete(info);
                        else if (editFlight == 0)
                            break;
                        break;
                    case 5:
                        Console.WriteLine(@"1.Add passengers
2.Edit passengers
3.Delete passengers
0.Back");
                        int editPassenger = int.Parse(Console.ReadLine());                       
                        if (editPassenger == 1)
                            p.Add(info);
                        else if (editPassenger == 2)
                            p.Edit(info);
                        else if (editPassenger == 3)
                            p.Delete(info);
                        else if (editPassenger == 0)
                            break;
                        break;
                    case 6:                                        
                        Console.WriteLine(@"1.Search by city arrived
2.Search by city departure
3.Search by flight number
4.Search by firstname of passenger
5.Search by lastName of passenger
6.Search by № passport of passenger
7.Search by price of fligth for economy class
0.Back");
                        int search = int.Parse(Console.ReadLine());
                        if (search == 1)
                            f.SearchCityArrival(info);
                        else if (search == 2)
                            f.SearchCityDeparture(info);
                        else if (search == 3)
                            f.SearchNumber(info);
                        else if (search == 4)
                            p.SearchByFirstName(info);
                        else if (search == 5)
                            p.SearchByLastName(info);
                        else if (search == 6)
                            p.SearchByPassport(info);
                           else if (search == 7)
                            f.SearchPrice(info);
                        else if (search == 0)
                            break;
                        break;
                }
            } while (menu != 0);
        }
    }
}
