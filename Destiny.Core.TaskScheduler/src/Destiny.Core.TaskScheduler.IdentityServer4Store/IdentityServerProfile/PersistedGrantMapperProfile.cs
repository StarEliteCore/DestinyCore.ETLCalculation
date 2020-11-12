using AutoMapper;
using Destiny.Core.TaskScheduler.Domain.Models.IdentityServerFour;

namespace Destiny.Core.TaskScheduler.IdentityServerFourStore.IdentityServerProfile
{
    public class PersistedGrantMapperProfile : Profile
    {
        public PersistedGrantMapperProfile()
        {
            CreateMap<PersistedGrant, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
                            .ReverseMap();
        }
    }
}
