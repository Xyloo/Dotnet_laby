using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Fruit
    {
        public string Name { get; set; }
        public bool IsSweet { get; set; }
        public decimal Price { get; set; }
        public decimal UsdPrice => Price / UsdCourse.Current;

        public static Fruit Create()
        {
            var r = new Random();

            string[] names =
            {
                "Apple", "Banana", "Cherry", "Durian", "Elderberry", "Grape", "Jackfruit", "Passionfruit", "Dragonfruit"
            };

            return new Fruit
            {
                Name = names[r.Next(names.Length)],
                IsSweet = r.NextDouble() > 0.5,
                Price = r.Next(1000) / 100m
            };
        }

        public override string ToString()
        {
            return $"Fruit: Name={Name}, IsSweet={IsSweet}, Price={Price:C2}, UsdPrice={MyFormatter.FormatUsdPrice(UsdPrice)}";
        }
    }
}
