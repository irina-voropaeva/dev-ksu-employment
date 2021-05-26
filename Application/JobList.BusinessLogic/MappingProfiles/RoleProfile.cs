using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, Role>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Role, RoleDTO>();

            CreateMap<RoleDTO, Role>();

            CreateMap<RoleRequest, Role>();

        }
    }
}
