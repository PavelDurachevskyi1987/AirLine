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
        public class Passenger : IPassengerSearch
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

        Adress adress = new Adress();

        public void Delete(AirLineInfo[] mass)
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
                Console.WriteLine("Enter the flight number to delete passenger");
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
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                        {
                            if (numberDelete == mass[i].Flight.FlightNumber)
                                if (mass[i].Flight.Passenger[j] != null)
                                    Console.WriteLine(mass[i].Flight.Passenger[j].ToString());
                        }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter the passport number to delete passenger");
                Console.ResetColor();
                int numberPassportDelete = int.Parse(Console.ReadLine());
                int countPassengerDelete = -1;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                        {
                            if (mass[i].Flight.Passenger[j] != null)
                            {
                                if (numberPassportDelete == mass[i].Flight.Passenger[j].Passport)
                                {
                                    countPassengerDelete = j;
                                }
                            }
                        }
                }
              
                        for (int j = countPassengerDelete; j < mass[positionDelete].Flight.Passenger.Length - 1; j++)
                        {
                            mass[positionDelete].Flight.Passenger[j] = mass[positionDelete].Flight.Passenger[j + 1];
                        } 
            }
        }
        public void Add(AirLineInfo[] mass)
        {
                adress.PrintAdress();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        Console.WriteLine(mass[i].Flight.ToString()); 
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter the flight number to add passenger");
                Console.ResetColor();
                int numberAdd = int.Parse(Console.ReadLine());
                int positionAdd = -1;
                Console.Clear();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        if (numberAdd == mass[i].Flight.FlightNumber)
                        {
                            positionAdd = i;
                        }
                    }
                }   
            Console.WriteLine("Enter First Name:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter nationality:");
            Nationality = Console.ReadLine();
            Console.WriteLine("Enter Passport:");
            Passport = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of birth(dd/mm/yyyy)");
            Birthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(@"Select a sex:
1.Male
2.Famale");
            int sex = int.Parse(Console.ReadLine());
            if (sex == 1)
                Sex = Sex.Male;
            else if(sex == 2)        
                Sex = Sex.Famale;
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
            int count = 0;      
            for (int i = 0; i < mass[positionAdd].Flight.Passenger.Length; i++)
            {
                if (mass[positionAdd].Flight.Passenger[i] != null)
                    count++;
            }
            int position = count + 1;
            mass[positionAdd].Flight.Passenger[position] = new Passenger(FirstName, LastName, Nationality,
                                                                 Passport, Birthday, Sex, FlightTicket);
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
                Console.WriteLine("Enter the flight number to edit passenger");
                Console.ResetColor();
                int numberEdit = int.Parse(Console.ReadLine());
                int positionEdit = -1;
                Console.Clear();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        if (numberEdit == mass[i].Flight.FlightNumber)
                        {
                            positionEdit = i;
                        }
                    }
                }
                adress.PrintAdress();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                        {
                            if (numberEdit == mass[i].Flight.FlightNumber)
                                if (mass[i].Flight.Passenger[j] != null)
                                    Console.WriteLine(mass[i].Flight.Passenger[j].ToString());
                        }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter the passport number to edit passenger");
                Console.ResetColor();
                int numberPassport = int.Parse(Console.ReadLine());
                int countPassenger = 0;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                        {
                            if (mass[i].Flight.Passenger[j] != null)
                            {
                                if (numberPassport == mass[i].Flight.Passenger[j].Passport)
                                {
                                    countPassenger = j;
                                }
                            }
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Enter First Name:");
                FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                LastName = Console.ReadLine();
                Console.WriteLine("Enter nationality:");
                Nationality = Console.ReadLine();
                Console.WriteLine("Enter Passport:");
                Passport = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter date of birth(dd/mm/yyyy)");
                Birthday = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(@"Select a sex:
1.Male
2.Famale");
                int sex = int.Parse(Console.ReadLine());
                if (sex == 1)
                    Sex = Sex.Male;
                else if (sex == 2)
                    Sex = Sex.Famale;
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
                 mass[positionEdit].Flight.Passenger[countPassenger] = new Passenger(FirstName, LastName, Nationality,
                                                                    Passport, Birthday, Sex, FlightTicket);
            }
        }
        public void Print(AirLineInfo[] mass)
        {
            adress.PrintAdress();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    Console.WriteLine(mass[i].Flight.ToString());
                    for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                    {
                        if (mass[i].Flight.Passenger[j] != null)
                            Console.WriteLine(mass[i].Flight.Passenger[j].ToString());
                    }
                }
            }
            Console.ReadLine();
        }
        public void SearchByFirstName(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter firstname of passenger: ");
            string firstName = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                    {
                        if (mass[i].Flight.Passenger[j] != null)
                        {
                            if (mass[i].Flight.Passenger[j].FirstName == firstName)
                            {
                                Console.WriteLine(mass[i].Flight.ToString());
                                Console.WriteLine(mass[i].Flight.Passenger[j].ToString());
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

        public void SearchByLastName(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter lastdName of passenger: ");
            string lastName = Console.ReadLine();
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                    {
                        if (mass[i].Flight.Passenger[j] != null)
                        {
                            if (mass[i].Flight.Passenger[j].LastName == lastName)
                            {
                                Console.WriteLine(mass[i].Flight.ToString());
                                Console.WriteLine(mass[i].Flight.Passenger[j].ToString());
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

        public void SearchByPassport(AirLineInfo[] mass)
        {
            Console.Clear();
            Console.WriteLine("Enter № passport of passenger: ");
            int numberPassport = int.Parse(Console.ReadLine());
            bool count = true;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] != null)
                {
                    for (int j = 0; j < mass[i].Flight.Passenger.Length; j++)
                    {
                        if (mass[i].Flight.Passenger[j] != null)
                        {
                            if (mass[i].Flight.Passenger[j].Passport == numberPassport)
                            {
                                Console.WriteLine(mass[i].Flight.ToString());
                                Console.WriteLine(mass[i].Flight.Passenger[j].ToString());
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
        public override string ToString()
        {            
            string myString = @"FirstName: " + FirstName + "\nLastName: " + LastName + "\nNationality: " + Nationality +
                "\nPassport: " + Passport + "\nBirthday: " + Birthday.Date + "\nSex: " + Sex +
                "\nFlight class: " + FlightTicket.FlightClass + "\nPrice: " + FlightTicket.Price +
                "\n" + new string('_', 30);
            return myString;
        }
    }
}
