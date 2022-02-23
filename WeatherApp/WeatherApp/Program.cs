using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        const string url = "http://api.weatherapi.com/v1/current.json?key=8a10fccef8c64fe4be8174632221502&q=Kazan&aqi=no";

        static void ShowWeather(Weather weather)
        {
            Console.WriteLine($"Location name: {weather.Location.Name}\n" +
                              $"Last updated time: {weather.Current.Last_updated}\n" +
                              $"Request sent time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
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


        static async Task Main(string[] args)
        {
            IObservable<long> obs  = Observable.Timer(DateTimeOffset.Now.AddSeconds(1), TimeSpan.FromSeconds(2)).Take(10);

            obs.Subscribe(_ => RunAsync().GetAwaiter().GetResult());

            await new TaskCompletionSource<object>().Task;
        }

        static async Task RunAsync()
        {
            try
            {
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
