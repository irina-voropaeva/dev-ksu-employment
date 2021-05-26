using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class EducationPeriodProfile : Profile
    {
        public EducationPeriodProfile()
        {
            CreateMap<EducationPeriod, EducationPeriod>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<EducationPeriod, EducationPeriodDTO>();

            CreateMap<EducationPeriodDTO, EducationPeriod>();

            CreateMap<EducationPeriodRequest, EducationPeriod>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
