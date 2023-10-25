﻿using Apps.Data.Processor;
using Apps.Data.Processor.Extensions;
using Apps.Data.Processor.Provider.MappingProfiles;
using Apps.Dataprocessor.Common;
using Apps.Dataprocessor.Common.Interfaces;
using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Factories.Interfaces;
using Apps.DataProcessor.DataAccess.Interfaces;
using Apps.DataProcessor.DataAccess.Repositories;
using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Apps.Data.Processor
{
    public class Startup : FunctionsStartup
    {

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var context = builder.GetContext();

            builder.ConfigurationBuilder
                .SetBasePath(context.ApplicationRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
            

            builder.Services.AddFactories();
            builder.Services.AddProviders();
            builder.Services.AddTransient<ISecretReader,KeyVaultSecretReader>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();

            var keyVaultReader = builder.Services.BuildServiceProvider().GetService<ISecretReader>();

            builder.Services.AddDbContext<UserDBContext>(options =>
                 options.UseSqlServer(keyVaultReader.GetSecret(configuration["KeyVaultUrl"], configuration["MainDBConnectionSecret"])));
            builder.Services.AddSingleton(CreateMapper());
        }

        private static IMapper CreateMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.AddProfiles(typeof(UserToUserModel).Assembly);
            });

            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.AddProfiles(typeof(UserToUserModel).Assembly);
            }).CreateMapper();
        }
    }
}
