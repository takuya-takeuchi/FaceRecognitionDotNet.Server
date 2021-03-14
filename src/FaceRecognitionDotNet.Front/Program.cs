using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FaceRecognitionDotNet.Front
{

    public sealed class Program
    {

        #region Methods

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var urls = args.Length == 0 ? new[] { "http://localhost:5000", "https://localhost:5001" } : args;

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseUrls(urls)
                        .UseKestrel();
                });
        }

        #endregion

    }

}