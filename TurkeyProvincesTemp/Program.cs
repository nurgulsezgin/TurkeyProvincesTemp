using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
string[] provincesList = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "turkiyedekiIller.txt")).Replace(" ","").Split(',');
foreach (var province in provincesList)
{
    app.MapGet(string.Format("/tempature/city={0}", province), () => appMapGetModelJson(province));
}
RouteHandlerBuilder routeHandlerBuilder = app.MapGet("/", (Func<List<User>>)(() => new() { new("Nurgül", "Sezgin") }));

app.Run();

static string appMapGetModelJson(string cityName) 
{
    // Create an HttpClient instance
    WebClient client = new WebClient();
    string content = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0},tr&APPID=8f916d970abee3b68204508eeeb3695a&units=metric",cityName);
    //string json = File.ReadAllText("C:\\nurgul\\nurgul.json", Encoding.UTF8);
    string json = client.DownloadString(content);
    TurkeyProvincesTemp.Model.WeatherForecast.Root json2 = JsonConvert.DeserializeObject<TurkeyProvincesTemp.Model.WeatherForecast.Root>(json);

    TurkeyProvincesTemp.Model.TempatureItem sýcaklýk = new TurkeyProvincesTemp.Model.TempatureItem();
    sýcaklýk.tempature = json2.main.temp;

    return JsonConvert.SerializeObject(sýcaklýk);
}
public record User(string Name, string LastName)
{
    public string FullName()
    {
        return this.Name + " " + LastName;
    }
}
