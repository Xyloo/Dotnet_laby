// See https://aka.ms/new-console-template for more information

using Lab2;

void Zadanie2_1()
{
    var fruits = new List<Fruit>();
    for (var i = 0; i < 15; i++)
    {
        fruits.Add(Fruit.Create());
    }

    foreach (var fruit in fruits.Where(x => x.IsSweet).OrderByDescending(x => x.Price))
    {
        Console.WriteLine(fruit);
    }
}
UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();
Zadanie2_1();