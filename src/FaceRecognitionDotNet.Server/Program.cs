using System;
using System.Globalization;
using System.IO;
using System.Linq;
using FaceRecognitionDotNet.Server.Data;
using FaceRecognitionDotNet.Server.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace FaceRecognitionDotNet.Server
{

    internal sealed class Program
    {

        #region Fields

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Logger.Error("FaceRecognitionDotNet.Server <cache size> <model directories> (urls)");
                return;
            }

            var size = args[0];
            if (!uint.TryParse(size, NumberStyles.Integer, new CultureInfo("en-us"), out var cacheSize) || cacheSize == 0)
            {
                Logger.Error($"cache size: '{size}' must be positive integer and more than 0.");
                return;
            }

            var models = args[1];
            if (!Directory.Exists(models))
            {
                Logger.Error($"model directories: '{models}' does not exist.");
                return;
            }

            try
            {
                Logger.Info("Create caches...");
                Cache.Initialize(models, cacheSize);
            }
            catch (Exception e)
            {
                Logger.Fatal(e, "Failed to initialize caches");
                return;
            }

            var host = CreateHostBuilder(args.Skip(2).ToArray()).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<LocalDbContext>();
                    DatabaseInitializer<LocalDbContext>.Initialize(context);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "An error occurred while seeding the database");
                }
            }

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
