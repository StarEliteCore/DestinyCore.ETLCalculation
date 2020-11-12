using AutoMapper;
using Destiny.Core.TaskScheduler.Domain.Models.SystemFoundation.DataDictionary;

namespace Destiny.Core.TaskScheduler.Dtos.DataDictionaryDto
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, TreeDictionaryOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Title));
        }
    }
}