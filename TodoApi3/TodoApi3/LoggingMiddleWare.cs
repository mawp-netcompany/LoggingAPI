namespace TodoApi3
{
    public class LoggingMiddleWare
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Log("================");

            var startTime = DateTime.Now;

            Log("StartDateTime: " + startTime.ToString());

            await _next(context);

            var endTime = DateTime.Now;
            Log("EndDateTime: " + endTime.ToString());

            var elapsedMilliseoncds = (endTime - startTime).TotalMilliseconds;
            Log("ElapsedTimeInMilliseconds: " + elapsedMilliseoncds.ToString());

            var response = context.Response.StatusCode;
            Log("Response: " + response.ToString());

            var request = context.Request.Method;
            Log("Request: " + request.ToString());

            var userName = Environment.UserName;
            Log("Username: " + userName.ToString());

            var SuccesfullIndicator = response == 200;
            Log("SuccesfulIndicator: " + SuccesfullIndicator.ToString());

            var clientAddress = context.Request.HttpContext.Connection.RemoteIpAddress;
            if (clientAddress != null)
                Log("ClientAddress: " + clientAddress.ToString());

            var serverIPAddress = context.Request.HttpContext.Connection.LocalIpAddress;
            if (serverIPAddress != null)
                Log("serverIPAddress: " + serverIPAddress.ToString());
        }

        private static void Log(string message)
        {
            StreamWriter SW = new("log.txt", true);
            SW.WriteLine(message);
            SW.Close();
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleWare>();
        }
    }
}
