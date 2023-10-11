// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Lab2;

void CreateAndListFruit(int amount)
{
    var fruits = new List<Fruit>();
    for (var i = 0; i < amount; i++)
    {
        fruits.Add(Fruit.Create());
    }

    foreach (var fruit in fruits.Where(x => x.IsSweet).OrderByDescending(x => x.Price))
    {
        Console.WriteLine(fruit);
    }
}
UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();
Console.WriteLine($"Current PLN->USD course: {UsdCourse.Current}");
CreateAndListFruit(15);