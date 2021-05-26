using AutoMapper;
using KsuEmployment.DataAccess.Data;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;

namespace KsuEmployment.DataAccess.Repositories
{
    public class InvitationsRepository : Repository<Invitation, int>, IInvitationsRepository
    {
        public InvitationsRepository(KsuEmploymentDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
