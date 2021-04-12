using AutoMapper;
using DestinyCore.WorkNode.Domain.Models.SystemFoundation.DataDictionary;

namespace DestinyCore.WorkNode.Dtos.DataDictionaryDto
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, TreeDictionaryOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Title));
        }
    }
}