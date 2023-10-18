using Apps.Data.Processor;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Apps.Data.Processor
{
    public class Startup : FunctionsStartup
    {

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var context = builder.GetContext();

            var configuration = builder.ConfigurationBuilder
                .SetBasePath(context.ApplicationRootPath)
                .AddJsonFile("appsettings.json", optional: true,
                    reloadOnChange: false).Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
        }
    }
}
