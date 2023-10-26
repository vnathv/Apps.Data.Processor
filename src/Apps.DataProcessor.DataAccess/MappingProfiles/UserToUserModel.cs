using Apps.Data.Processor.Infrastructure;
using Apps.DataProcessor.DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataProcessor.DataAccess.MappingProfiles
{
    public class UserToUserModel : Profile
    {
        public UserToUserModel()
        {
            CreateMap<UserModel, UserRecord>()
                .ForMember(x => x.RecordId, opt => opt.Ignore())
                .ForMember(x => x.CreatedDateTime, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedDateTime, opt => opt.Ignore())
                .ForMember(x => x.NotificationFlag, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
