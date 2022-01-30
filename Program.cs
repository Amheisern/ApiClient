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
            Console.WriteLine("                              !         !               ");
            Console.WriteLine("                             ! !       ! !");
            Console.WriteLine("                            ! . !     ! . !");
            Console.WriteLine("                             !.!       !.!");
            Console.WriteLine("                             ^ ^^^^^^^^^ ^   ");
            Console.WriteLine("                            ^            ^  ");
            Console.WriteLine("                          ^  (0)      (0)  ^    ");
            Console.WriteLine("                        ^         @          ^   ");
            Console.WriteLine("                       ^    ***************    ^    ");
            Console.WriteLine("                    ^   *                     *  ^    ");
            Console.WriteLine("                  ^   *      /|   /|   /|      *   ^    ");
            Console.WriteLine("                 ^   *                          *   ^  ");
            Console.WriteLine("                ^   *     /|   /|   /|   /|      *   ^ ");
            Console.WriteLine("               ^   *                              *   ^ ");
            Console.WriteLine("               ^   *                             *   ^ ");
            Console.WriteLine("                 ^  *                            *  ^  ");
            Console.WriteLine("                 ^  *                           *  ^   ");
            Console.WriteLine("                   ^ *                         *  ^    ");
            Console.WriteLine("                    ^*                        * ^    ");
            Console.WriteLine("                      ^ *         ) (        *   ^    ");
            Console.WriteLine("                          ^^^^^^^    ^^^^^^^    ");
            Console.WriteLine("           ----------------------------------------------------");
            Console.WriteLine("                     Welcome to the Ghibli database");
            Console.WriteLine("           ----------------------------------------------------");
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
                Console.WriteLine("Display all (M)ale characters");
                Console.WriteLine("Display all (F)emale characters");
                Console.WriteLine("(Q)uit to exit menu");
                var choice = Console.ReadLine().ToUpper();
                var url = "https://ghibliapi.herokuapp.com/people/";

                switch (choice)
                {
                    case "D":
                        await ShowAllPeople();
                        break;
                    case "M":
                        await ShowAllMale(url);
                        break;
                    case "F":
                        await ShowAllFemale(url);
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

        private static async Task ShowAllFemale(string url)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync(url);
            var peoples = await JsonSerializer.DeserializeAsync<List<People>>(responseAsStream);
            var allFemales = peoples.Where(people => people.Gender == "Female");
            Console.WriteLine($" This is how many female characters there are {allFemales.Count()}");
            foreach (var people in allFemales)
            {
                Console.WriteLine($"These are the names of the female characters: {people.Name}");
            }
        }

        private static async Task ShowAllMale(string url)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync(url);
            var peoples = await JsonSerializer.DeserializeAsync<List<People>>(responseAsStream);
            var allMales = peoples.Where(people => people.Gender == "Male");
            foreach (var people in allMales)
            {
                Console.WriteLine($"These are the names of the male characters: {people.Name} there age is {people.parsedAge}");
            }
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
        public class Digits
        {
            public static string Explode(string s)
            {
                var cuts = s.Split();
                foreach (var cut in cuts)
                {
                    return (cut);
                }
                //var explode = cuts.Select(cut => cut. (cut));
                return explode;
                // Insert your solution here
                return "";
            }
        }
    }
}

