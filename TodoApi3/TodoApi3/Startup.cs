using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;

namespace TodoApi3
{
    public class Startup
    {
        private IConfiguration _config;
        private readonly RequestDelegate _next;

        public Startup(IConfiguration config, RequestDelegate next)
        {
            _config = config;
            _next = next;
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            }) ;


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                Log("================");

                var startTime = DateTime.Now;

                Log("StartDateTime: " + startTime.ToString());
                

                await context.Response.WriteAsync("Hello World");

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

                await _next(context);
            });
        }

        private static void Log(string message)
        {
            StreamWriter SW = new("log.txt", true);
            SW.WriteLine(message);
            SW.Close();
        }
    }
}
