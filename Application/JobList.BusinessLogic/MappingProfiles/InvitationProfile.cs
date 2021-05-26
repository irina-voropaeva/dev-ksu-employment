using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.MappingProfiles
{
    public class InvitationProfile : Profile
    {
        public InvitationProfile()
        {
            CreateMap<Invitation, Invitation>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Invitation, InvitationDTO>();

            CreateMap<FavoriteVacancyDTO, Invitation>();

            CreateMap<InvitationRequest, Invitation>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
