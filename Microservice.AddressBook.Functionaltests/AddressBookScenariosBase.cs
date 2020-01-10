using Microservices.AddressBook.API;
using Microservices.AddressBook.API.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Reflection;

namespace Micoservices.AddressBook.FunctionalTests
{
    public class AddressBookScenariosBase
    {
        public TestServer CreateServerNoaction()
        {
            var path = Assembly.GetAssembly(typeof(AddressBookScenariosBase))
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                })
                .UseStartup<Startup>();

            return  new TestServer(hostBuilder);
        }

            public TestServer CreateServer()
        {
            var testServer = CreateServerNoaction();
            CreateDbIfNotExists(testServer.Host);

            return testServer;
        }
  

        public  static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AddressBookContext>();
                    AddressBookContextDbSeed.Seed(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

      
        public static class Get
        {
            public static string AddressBook()
            {
                return $"api/addressbook";
            }           
        }
    }
}
