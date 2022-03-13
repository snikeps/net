using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Program
    {
        const string url = "http://api.weatherapi.com/v1/current.json?key=8a10fccef8c64fe4be8174632221502&q=Kazan&aqi=no";

        static HttpClient client = new HttpClient();

        static List<Weather> weatherRecords = new List<Weather>();

        static void ShowWeather(Weather weather, int count, double meanHumidity)
        {
            Console.WriteLine($"Location name: {weather.Location.Name}\n" +
                              $"Last updated time: {weather.Current.Last_updated}\n" +
                              $"Request sent time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
                              $"Humidity: {weather.Current.Humidity}\n" + 
                              $"Today's measurements count: {count}\n" +
                              $"Mean humidity for last six hours: {meanHumidity}");
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
            var obs = Measurement();

            obs.Subscribe(_ => RunAsync().GetAwaiter().GetResult());

            await new TaskCompletionSource<object>().Task;
        }

        static async Task RunAsync()
        {
            try
            {
                var weather = await GetWeatherAsync(url);

                var count = GetCountOfUniqueMeasures(weather);

                var meanHumidity = GetMeanHumididty();

                ShowWeather(weather, count, meanHumidity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static int GetCountOfUniqueMeasures(Weather weather)
        {
            weatherRecords.Add(weather);

            return weatherRecords
                        .Select(x => DateTime.Parse(x.Current.Last_updated) > DateTime.Today)
                        .Distinct()
                        .Count();
        }

        private static double GetMeanHumididty()
        {
            var sumOfHumidity =  weatherRecords
                                    .Select(x => x.Current)
                                    .Where(x => DateTime.Parse(x.Last_updated) > DateTime.Now.AddHours(-6))
                                    .Sum(x => x.Humidity);

            var countOfHumidity = weatherRecords
                                    .Select(x => x.Current)
                                    .Where(x => DateTime.Parse(x.Last_updated) > DateTime.Now.AddHours(-6))
                                    .Count();

            return sumOfHumidity / countOfHumidity;
        }


        static IObservable<long> Measurement()
        {
            return Observable.Create<long>(
                (obs, cancel) =>
                {
                    return Task.Run(() =>
                    {
                        while (!cancel.IsCancellationRequested)
                        {
                            Thread.Sleep(10 * 1000);
                            obs.OnNext(100);
                        }
                    });
                });
        }
    }
}
