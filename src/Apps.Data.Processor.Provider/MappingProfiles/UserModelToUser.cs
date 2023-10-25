using Apps.Data.Processor.Infrastructure;
using Apps.DataProcessor.DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Data.Processor.Provider.MappingProfiles
{
    public class UserToUserModel : Profile
    {
        public UserToUserModel()
        {
            CreateMap<UserRecord, UserDto>()
                .ReverseMap();
        }
    }
}
