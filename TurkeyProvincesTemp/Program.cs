var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Nurg�l Sezgin");
app.MapGet("/tempature", () => "S�cakl�k");

app.Run();
