using Apps.DataProcessor.DataAccess.Entities;

namespace Apps.DataProcessor.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserRecord> GetLastUpdatedUsers(DateTime currentDateTime, int timeIntervalInMinutes);
    }
}
