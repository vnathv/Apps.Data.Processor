using Apps.Data.Processor.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Data.Processor.Provider.Interface
{
    public interface IUserProvider
    {
        Task<IEnumerable<UserModel>> GetLastUpdatedUsers(int timeIntervalInMinutes);
    }
}
