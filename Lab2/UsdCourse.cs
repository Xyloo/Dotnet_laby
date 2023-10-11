using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lab2
{
    internal class UsdCourse
    {
        public static decimal Current = 0;

        public static async Task<decimal> GetUsdCourseAsync()
        {
            var wc = new HttpClient();
            var response = await wc.GetAsync("http://www.nbp.pl/kursy/xml/LastA.xml");
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException();

            XElement xe = XElement.Parse(await response.Content.ReadAsStringAsync());
            var x = xe.Descendants("pozycja")
                .FirstOrDefault(x => x.Element("kod_waluty")?.Value == "USD")
                ?.Element("kurs_sredni")?.Value;

            var parseSuccessful = decimal.TryParse(x, out decimal result);

            if (!parseSuccessful)
                throw new InvalidOperationException();

            return result;
        }
    }
}
