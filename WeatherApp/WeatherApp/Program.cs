using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowWeather(Weather weather)
        {
            Console.WriteLine($"Location name: {weather.Location.Name}\n" +
                              $"Last updated time: {weather.Current.Last_updated}\n" +
                              $"Humidity: {weather.Current.Humidity}");
        }

        static async Task<Weather> GetWeatherAsync(string path)
        {
            string message = "";

            HttpResponseMessage response = await client.GetAsync(path);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                message = await response.Content.ReadAsStringAsync();
            }
            Weather weather = JsonConvert.DeserializeObject<Weather>(message);

            return weather;
        }


        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                var url = "http://api.weatherapi.com/v1/current.json?key=8a10fccef8c64fe4be8174632221502&q=Kazan&aqi=no";

                var weather = await GetWeatherAsync(url);

                ShowWeather(weather);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
