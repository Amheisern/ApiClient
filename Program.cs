using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;
using System.Linq;

namespace GhibliStatus
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("         Welcome to the Ghibli database");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static async Task Main(string[] args)
        {


            var keepGoing = true;

            DisplayGreeting();

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose from the menu");
                Console.WriteLine("(D)isplay all characters and stats");
                Console.WriteLine(" Display all (M)ale characters");
                Console.WriteLine("(U)pdate signed status of band");
                Console.WriteLine("(Q)uit to exit menu");
                var choice = Console.ReadLine().ToUpper();
                var url = "https://ghibliapi.herokuapp.com/people/";

                switch (choice)
                {
                    case "D":
                        await ShowAllPeople();
                        break;
                    case "M":
                        var client = new HttpClient();
                        // Make a `GET` request to the API and get back a *stream* of data.
                        var responseAsStream = await client.GetStreamAsync(url);
                        var peoples = await JsonSerializer.DeserializeAsync<List<People>>(responseAsStream);
                        var allMales = peoples.Where(people => people.Gender == "Male");
                        foreach (var people in allMales)
                        {
                            Console.WriteLine($"These are the names of the make characters: {people.Name}");
                        }

                        break;
                    case "F":
                        var client = new HttpClient();
                        // Make a `GET` request to the API and get back a *stream* of data.
                        var responseAsStream = await client.GetStreamAsync(url);
                        var peoples = await JsonSerializer.DeserializeAsync<List<People>>(responseAsStream);
                        var allMales = peoples.Where(people => people.Gender == "Male");
                        foreach (var people in allMales)
                        {
                            Console.WriteLine($"These are the names of the make characters: {people.Name}");
                        }
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye!");
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("That was not a valid selection! Please Try again");
                        break;

                }
            }




            //Console.WriteLine(responseAsString);
        }

        static async Task ShowAllPeople()
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://ghibliapi.herokuapp.com/people/");
            //Console.WriteLine(responseAsStream);
            var peoples = await JsonSerializer.DeserializeAsync<List<People>>(responseAsStream);
            var table = new ConsoleTable("Name", "Gender", "Age", "Eye Color", "Eye Color");

            foreach (var people in peoples)
            {
                table.AddRow(people.Name, people.Gender, people.Age, people.EyeColor, people.HairColor);

                //Console.WriteLine($"The character {people.Name} has {people.EyeColor} eyes and {people.HairColor} hair.");
            }
            table.Write();
        }
    }
}

