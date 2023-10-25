using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Entities;
using Apps.DataProcessor.DataAccess.Factories.Interfaces;
using Apps.DataProcessor.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Apps.DataProcessor.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext userDBContext;

        public UserRepository(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }


        

        public IEnumerable<UserRecord> GetLastUpdatedUsers(DateTime currentDateTime, int timeIntervalInMinutes)
        {
            var lastUpdatedDateTime = DateTime.Now.AddMinutes(-15);

            var users1 = userDBContext.Users.FirstOrDefault();

            var param = new SqlParameter("@LastUpdatedDateTime", lastUpdatedDateTime);
            var users = userDBContext.Users
                .FromSqlRaw(@"exec dbo.GetUpdatedUsers @LastUpdatedDateTime", param)
                .ToList();

            return users;
        }
    }
}
