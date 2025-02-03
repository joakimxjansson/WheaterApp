
namespace Väderapp;


public class WeatherResponse
{
   
    public Sys sys { get; set; }
    public  MainWeather main { get; set; }
    public Weather[] weather { get; set; }
    public string name { get; set; }
    


    
}
