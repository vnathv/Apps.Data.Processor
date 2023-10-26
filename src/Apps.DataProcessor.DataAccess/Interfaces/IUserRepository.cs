using Apps.Data.Processor.Infrastructure;
using Apps.DataProcessor.DataAccess.Entities;

namespace Apps.DataProcessor.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetLastUpdatedUsers(int timeIntervalInMinutes);
    }
}
