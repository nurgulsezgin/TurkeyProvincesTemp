using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


RouteHandlerBuilder routeHandlerBuilder = app.MapGet("/", (Func<List<User>>)(() => new() { new("Nurgül", "Sezgin") }));
app.MapGet("/tempature", () => "Sýcaklýk");

app.Run();


public record User(string Name, string LastName)
{
    public string FullName()
    {
        return this.Name + " " + LastName;
    }
}