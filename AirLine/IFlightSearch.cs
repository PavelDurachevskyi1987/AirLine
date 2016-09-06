using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    interface IFlightSearch
    {
        void SearchCityArrival(AirLineInfo[] mass);
        void SearchCityDeparture(AirLineInfo[] mass);
        void SearchPrice(AirLineInfo[] mass);
        void SearchNumber(AirLineInfo[] mass);
    }
}
