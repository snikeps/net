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

            var response = await client.GetAsync(path);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                message = await response.Content.ReadAsStringAsync();
            }
            var weather = JsonConvert.DeserializeObject<Weather>(message);

            return weather;
        }


        static async Task Main(string[] args)
        {
            //можно сверху вставить ещё один таймер, который будет срабатывать каждые сутки и запускать заново последовательность).
            Observalbe.Timer(100,0)
                .Select(async s=> await GetWeatherAsync(url))
                .Scan(async (result,current)=>await CalculateMean(result,current))
                .Subscribe(async k =>ShowWeather((await k).last,(await k).count,(await k).mean));             
        }

        static async  Task<(double mean, double count, Weather last,double lastSum,double lastTime)> CalculateMean(Task<(double mean, double count, Weather previous)> previousResult, Task<Weather> currentResult)
        {
            var (mean,count,previous,lastSum,lastTime) = await previousResult;
            var current = await currentResult;
            var elapsedFromPrevious = current.Current.Last_updated - previous.Current.Last_updated;
            var currentWeightedMean = elapsedFromPrevious * (current.Current.Humidity + previous.Current.Humidity) / 2;
            return ((currentWeightedMean + lastSum)/(lastTime + elapsedFromPrevious),
                     count+1,
                     current,
                     (currentWeightedMean + lastSum),
                     (lastTime + elapsedFromPrevious));
        }


    }
}
