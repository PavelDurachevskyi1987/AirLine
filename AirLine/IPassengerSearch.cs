using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    interface IPassengerSearch
    {
        void SearchByFirstName(AirLineInfo[] mass);
        void SearchByLastName(AirLineInfo[] mass);
        void SearchByPassport(AirLineInfo[] mass);
    }
}
