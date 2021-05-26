using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            CreateMap<City, City>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<City, CityDTO>();

            CreateMap<CityDTO, City>();

            CreateMap<CityRequest, City>();
        }
    }
}
