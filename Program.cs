using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

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

            static async Task Main(string[] args)
            {


                var keepGoing = true;

                DisplayGreeting();

                while (keepGoing)
                {

                }




                await ShowAllPeople();
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
}
