using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Apps.DataProcessor.DataAccess.Factories
{
    public class UserDBContextFactory : IUserDBContextFactory
    {
        public UserDBContext Create(string connectionString)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder()
                                            .UseSqlServer(connectionString);

            return new UserDBContext(dbContextOptionsBuilder.Options);
        }
    }
}
