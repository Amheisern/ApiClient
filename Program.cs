using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace GhibliStatus
{
    class Program
    {
        static async void Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://ghibliapi.herokuapp.com/people/");

            var peoples = await JsonSerializer.DeserializeAsync<List<People>>(responseAsStream);

            foreach (var people in peoples)
            {
                Console.WriteLine($"The character {people.Name} has {people.EyeColor} eyes and {people.HairColor} hair.");
            }
            //Console.WriteLine(responseAsString);
        }
    }
}
