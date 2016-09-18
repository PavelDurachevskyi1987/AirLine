namespace AirLine
{
    public enum FlightClass
    {
        Business,
        Ecocnomy
    }

    public class FlightTicket 
    {
        public float Price { get; private set; }
        public FlightClass FlightClass { get; private set; }

        public FlightTicket(FlightClass flightClass, float price)
        {
            FlightClass = flightClass;
            Price = price;
        }
    }
}