using TodoApi3;
using TodoApi3.Controllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
ITextWriter textWriter = new WeatherForecastController();

app.UseHttpsRedirection();

app.UseLogging();

app.Run(async (context) =>
{
    await context.Response.WriteAsync(textWriter.GetText());
});

app.Run();