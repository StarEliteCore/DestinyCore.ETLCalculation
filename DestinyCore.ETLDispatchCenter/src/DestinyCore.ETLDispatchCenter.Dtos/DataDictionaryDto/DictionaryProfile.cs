using AutoMapper;
using DestinyCore.ETLDispatchCenter.Domain.Models.SystemFoundation.DataDictionary;

namespace DestinyCore.ETLDispatchCenter.Dtos.DataDictionaryDto
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, TreeDictionaryOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Title));
        }
    }
}