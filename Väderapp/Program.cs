using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Väderapp;

class Program
{
    private static readonly string apiKey = "51e2214e6212e8cdf228a48ec785320a";



    static async Task GetWeather(string city)
    {
        string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(data);

               
                Console.WriteLine($"Väder i {weatherResponse.name}:");
                Console.WriteLine($"LandsID: {weatherResponse.sys.country}");
                Console.WriteLine($"Temperatur: {weatherResponse.main.temp}°C");
                Console.WriteLine($"Känns som: {weatherResponse.main.feels_like}°C");
                Console.WriteLine($"Väderbeskrivning: {weatherResponse.weather[0].description}");
                Console.WriteLine($"Luftfuktighet: {weatherResponse.main.humidity}%");
               
            }
            else
            {
                Console.WriteLine($"Fel vid hämtning av väderdata för {city}. Statuskod: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
        }
    }

    static async Task Main()
    {
        
        bool run = true;
        while (run) {
            
            Console.WriteLine("Ange en stad: eller avlsluta med 0 ");
            string city = Console.ReadLine();
            Console.Clear();
            if (city == "0") {
                run = false;
            } else {
                await GetWeather(city);
            }
            

        }
    }
        
}