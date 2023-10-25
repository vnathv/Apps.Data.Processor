using Apps.Data.Processor.Infrastructure;
using Apps.Data.Processor.Provider.Interface;
using Apps.Dataprocessor.Common.Interfaces;
using Apps.DataProcessor.DataAccess.Interfaces;
using AutoMapper;

namespace Apps.Data.Processor.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<UserDto> GetLastUpdatedUsers(DateTime currentDateTime, int timeIntervalInMinutes)
        {
            var users = userRepository.GetLastUpdatedUsers(currentDateTime, timeIntervalInMinutes);
           
            return Mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
