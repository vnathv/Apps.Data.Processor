using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Entities;
using Apps.DataProcessor.DataAccess.Factories.Interfaces;
using Apps.DataProcessor.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Apps.DataProcessor.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDBContextFactory userDBContextFactory;
        private readonly string connectionString;
        private UserDBContext userDBContext;

        public UserRepository(IUserDBContextFactory userDBContextFactory, string connectionString)
        {
            this.userDBContextFactory = userDBContextFactory;
            this.connectionString = connectionString;
        }

        private UserDBContext Context { get => userDBContext ?? (userDBContext = userDBContextFactory.Create(connectionString)); }

        public IEnumerable<User> GetUsers()
        {
            var LastUpdatedDateTime = DateTime.Now.AddMinutes(-15);

            var users = Context.Users
                .FromSqlRaw($"EXECUTE dbo.GetMostPopularBlogsForUser {LastUpdatedDateTime}")
                .ToList();

            return users;
        }
    }
}
