using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, Language>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Language, LanguageDTO>();

            CreateMap<LanguageDTO, Language>();

            CreateMap<LanguageRequest, Language>();
        }
    }
}
