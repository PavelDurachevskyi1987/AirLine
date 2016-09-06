using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    public class AirLineInfo 
    {
        public Adress Adress { get; set; }
        public Flight Flight;
        public AirLineInfo(Adress adress, Flight flight)
        {
            Adress = adress;
            Flight = flight;          
        }
    }
}
