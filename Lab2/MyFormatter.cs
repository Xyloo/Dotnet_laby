using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class MyFormatter
    {
        public static string FormatUsdPrice(double price)
        {
            var usc = new CultureInfo("en-US");
            return price.ToString("C2", usc);
        }
    }
}
