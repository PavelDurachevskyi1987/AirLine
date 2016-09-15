using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    interface ISearch
    {
        void SearchByFirstName();
        void SearchByLastName();
        void SearchByPassport();
        void SearchCityArrival();
        void SearchCityDeparture();
        void SearchPrice();
        void SearchNumberFLight();
    }
}
