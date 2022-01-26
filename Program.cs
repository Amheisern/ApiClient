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
        static async Task Main(string[] args)
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
            //Console.WriteLine(responseAsString);
        }
    }
}
