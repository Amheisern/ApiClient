using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
            // Console.WriteLine(peoples[0]);
            foreach (var people in peoples)
            {
                Console.WriteLine($"The character {people.Name} has {people.EyeColor} eyes and {people.HairColor} hair.");
            }
            //Console.WriteLine(responseAsString);
        }
    }
}
