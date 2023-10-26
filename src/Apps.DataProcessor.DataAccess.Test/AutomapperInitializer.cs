using Apps.DataProcessor.DataAccess.MappingProfiles;
using AutoMapper;
using System.Reflection;

namespace Apps.DataProcessor.DataAccess.Test
{
    [TestClass]
    public class AutomapperInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var assemblies = new List<Assembly> {
                typeof(UserToUserModel).Assembly
            };

            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.AddProfiles(assemblies);
            });
        }
    }
}
