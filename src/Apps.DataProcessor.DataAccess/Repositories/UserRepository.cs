using Apps.Data.Processor.Infrastructure;
using Apps.DataProcessor.DataAccess.DBContext;
using Apps.DataProcessor.DataAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apps.DataProcessor.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext userDBContext;

        public UserRepository(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }
        

        public async Task<IEnumerable<UserModel>> GetLastUpdatedUsers(int timeIntervalInMinutes)
        {
            //COMMENT OUT LINE 25-34 IF NOT USING STORED PROCEDURE. FROMRAWSQL WON'R WORK WITH EF INMEMORY DATA FOR UNIT TEST

            //string timeIntervalParameter = "@TimeIntervalInMinutes";

            //var timeIntervalParam = new SqlParameter(timeIntervalParameter, timeIntervalInMinutes);
            
            //var users = await userDBContext.Users
            //    .FromSqlRaw($"exec {StoredProcedureName.GetUpdatedUsers} {timeIntervalParameter}", timeIntervalParam)
            //    .ToListAsync();

            //return Mapper.Map<IEnumerable<UserModel>>(users);

            //BELOW LOGIC IS FOR NOT STORED PROCEDURE

            DateTime currentDateTime = DateTime.Now;
            DateTime timeInterval = currentDateTime.AddMinutes(timeIntervalInMinutes);

            var userRecords = await userDBContext
                                    .Users
                                    .Where(a => a.LastUpdatedDateTime >= timeInterval && a.LastUpdatedDateTime <= currentDateTime)
                                    .ToListAsync();

            return Mapper.Map<IEnumerable<UserModel>>(userRecords);
        }
    }
}
