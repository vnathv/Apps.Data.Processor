using Apps.Data.Processor.Provider;
using Apps.Data.Processor.Provider.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Data.Processor.Extensions
{
    public static partial class ServiceProviderCollectionExtensions
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddTransient<IUserProvider, UserProvider>();
        }
    }
}
