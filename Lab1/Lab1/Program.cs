// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Lab1;
//Zadanie 1.3
static void FizzBuzz()
{
    for (var i = 1; i <= 100; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}

//Zadanie 1.4
static void ZgadnijLiczbe()
{
    var random = new Random();
    var randomNumber = random.Next(1, 101);
    var guessed = false;
    var guesses = 1;
    
    List<HighScore> highScores;
    const string fileName = "highscores.json";
    if (File.Exists(fileName))
    {
        highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(fileName))!;
    }
    else
    { 
        highScores = new List<HighScore>();
    }

    while (!guessed)
    {
        Console.WriteLine("Podaj liczbę:");
        var parseSuccessful = int.TryParse(Console.ReadLine(), out var input);
        if (!parseSuccessful)
        {
            Console.WriteLine("Nie podałeś liczby!");
            continue;
        }

        if (input == randomNumber)
        {
            Console.WriteLine($"Zgadłeś za {guesses} razem!");
            guessed = true;

            Console.WriteLine("Podaj swoje imię: ");
            var name = Console.ReadLine()!;
            var highScore = new HighScore
            {
                Name = name,
                Trials = guesses
            };
            highScores.Add(highScore);
            File.WriteAllText(fileName, JsonSerializer.Serialize(highScores));
        }
        else if (input < randomNumber)
        {
            Console.WriteLine("Za mało!");
        }
        else
        {
            Console.WriteLine("Za dużo!");
        }
        guesses++;
    }

    Console.WriteLine("Najlepsze wyniki:");
    foreach (var highScore in highScores.OrderBy(hs => hs.Trials))
    {
        Console.WriteLine($"{highScore.Name} -- {highScore.Trials} prób");
    }
}



//FizzBuzz();
ZgadnijLiczbe();
