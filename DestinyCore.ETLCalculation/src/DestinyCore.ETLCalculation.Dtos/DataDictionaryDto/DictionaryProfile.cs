using AutoMapper;
using DestinyCore.ETLCalculation.Domain.Models.SystemFoundation.DataDictionary;

namespace DestinyCore.ETLCalculation.Dtos.DataDictionaryDto
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, TreeDictionaryOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Title));
        }
    }
}