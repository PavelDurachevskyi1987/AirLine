﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    public static class Helper
    {
        public static void NothingFound()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nothing found !!!");
            Console.ResetColor();
        }
    }
}
