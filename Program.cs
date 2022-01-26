using System;
using System.Net.Http;

namespace GhibliStatus
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsString = await client.GetStringAsync("https://ghibliapi.herokuapp.com/people/");
            Console.WriteLine(responseAsString);
        }
    }
}
