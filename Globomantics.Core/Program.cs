using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Globomantics.Core
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
      Log.CloseAndFlush();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, provider, loggerConfiguration) =>
            {
              loggerConfiguration
                      .ReadFrom.Configuration(context.Configuration)
                      .Enrich.FromLogContext()
                      .WriteTo.Console()
                      //.WriteTo.Seq("http://localhost:5341");
                      // just for local development
                      //.WriteTo.Seq("http://host.docker.internal:5341");
                      .WriteTo.Seq("http://globoseq");
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
