using Apps.DataProcessor.DataAccess.Entities;

namespace Apps.DataProcessor.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
