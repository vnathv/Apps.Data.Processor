using Apps.DataProcessor.DataAccess.Factories;
using Apps.DataProcessor.DataAccess.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Data.Processor.Extensions
{
    public static partial class ServiceFactoryCollectionExtensions
    {
        public static void AddFactories(this IServiceCollection services)
        {
            //services.AddTransient<IUserDBContextFactory, UserDBContextFactory>();
        }
    }
}
