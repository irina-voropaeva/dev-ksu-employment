using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty, Faculty>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Faculty, FacultyDTO>();

            CreateMap<FacultyDTO, Faculty>();

            CreateMap<FacultyRequest, Faculty>();

        }
    }
}
