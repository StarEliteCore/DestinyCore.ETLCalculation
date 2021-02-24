using AutoMapper;
using DestinyCore.ETLDataCalculationTransMission.Domain.Models.SystemFoundation.DataDictionary;

namespace DestinyCore.ETLDataCalculationTransMission.Dtos.DataDictionaryDto
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, TreeDictionaryOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Title));
        }
    }
}