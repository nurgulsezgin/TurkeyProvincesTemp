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


RouteHandlerBuilder routeHandlerBuilder = app.MapGet("/", (Func<List<User>>)(() => new() { new("Nurgül", "Sezgin") }));
app.MapGet("/tempature", () => GetModelJson()); 
app.Run();
static string GetModelJson()
{
    // Create an HttpClient instance
    WebClient client = new WebClient();
    string content = string.Format("http://api.openweathermap.org/data/2.5/weather?q=Cleveland&APPID=8f916d970abee3b68204508eeeb3695a&units=imperial");
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
