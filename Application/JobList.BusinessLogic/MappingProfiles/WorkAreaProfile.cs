using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class WorkAreaProfile : Profile
    {
        public WorkAreaProfile()
        {
            CreateMap<WorkArea, WorkArea>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<WorkArea, WorkAreaDTO>();

            CreateMap<WorkAreaDTO, WorkArea>();

            CreateMap<WorkAreaRequest, WorkArea>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
