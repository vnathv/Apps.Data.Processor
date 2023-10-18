using Apps.Data.Processor.Infrastructure;
using Apps.Data.Processor.Provider.Interface;
using Apps.DataProcessor.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Data.Processor.Provider
{
    public class UserProvider : IUserProvider
    {
        public UserProvider(IUserRepository userRepository)
        {
            
        }
        public List<UserModel> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
