using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Entities;
using Apps.DataProcessor.DataAccess.Factories.Interfaces;
using Apps.DataProcessor.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Apps.DataProcessor.DataAccess.Repositories
{
    public class UserRepositoryCopy : IUserRepository
    {
       
        private readonly UserDBContext dbContext;
        private UserDBContext userDBContext;

       
        public UserRepositoryCopy(UserDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //private UserDBContext Context { get => userDBContext ?? (userDBContext = userDBContextFactory.Create(connectionString)); }

        public IEnumerable<UserRecord> GetLastUpdatedUsers(DateTime currentDateTime, int timeIntervalInMinutes)
        {
            var lastUpdatedDateTime = DateTime.Now.AddMinutes(-15);

           // var c = userDBContextFactory.Create("Data Source=vijcommonserver.database.windows.net;Initial Catalog=Vij_Main;User ID=bredanetherlands;Password=admin@123#;MultipleActiveResultSets=True;Encrypt=True");
            var users1 = dbContext.Users.ToList();
           
            return users1;
        }
    }
}
