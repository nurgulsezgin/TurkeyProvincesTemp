var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Nurgül Sezgin");
app.MapGet("/tempature", () => "Sýcaklýk");

app.Run();
