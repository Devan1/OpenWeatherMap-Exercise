using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace test
{
    public class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "7374f086c60369318f990ac8e308bf26";
            Console.WriteLine("What city would you like to check the weather?: ");
            var city = Console.ReadLine();

            var client = new HttpClient();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";
            var weatherResponse = client.GetStringAsync(weatherURL).Result;
            var weatherJson = JObject.Parse(weatherResponse).GetValue("main").ToString();
            var currentWeather = JObject.Parse(weatherJson).GetValue("temp").ToString();
            var feelsLike = JObject.Parse(weatherJson).GetValue("feels_like").ToString();
            var tempMin = JObject.Parse(weatherJson).GetValue("temp_min").ToString();
            var tempMax = JObject.Parse(weatherJson).GetValue("temp_max").ToString();
            var humidity = JObject.Parse(weatherJson).GetValue("humidity").ToString();


            foreach (var item in weatherJson)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine($"--------------------");

            Console.WriteLine(currentWeather);
            Console.WriteLine(feelsLike);
            Console.WriteLine(tempMin);
            Console.WriteLine(tempMax);
            Console.WriteLine(humidity);
            Console.WriteLine($"--------------------");

            Console.WriteLine($"The weather in {city} is:\nCurrent Weather: {currentWeather}," +
                $"\nFeels Like: {feelsLike}\nLow: {tempMin} degrees\nHigh: {tempMax} degrees\nHumidity: {humidity}%");
        }
    }
}
