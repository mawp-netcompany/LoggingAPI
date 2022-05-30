namespace TodoApi3
{
    public class WeatherForecast : ITextWriter
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        
        public string GetText()
        {
            string result = "";

            for (int i = 0; i < 5; i++)
            {
                result += "Date: " + DateTime.Now.AddDays(i).ToShortDateString() + ", ";
                result += "Temperature: " + Random.Shared.Next(-20, 55) + " degrees C, summary: ";
                result += "Summary: " + Summaries[new Random().Next() % Summaries.Length] + "\n";
            }

            return result;
        }
    }
}