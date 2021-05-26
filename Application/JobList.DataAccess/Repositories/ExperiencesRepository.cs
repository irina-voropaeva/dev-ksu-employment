using AutoMapper;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace KsuEmployment.DataAccess.Repositories
{
    public class ExperiencesRepository : Repository<Experience, int>, IExperiencesRepository
    {
        public ExperiencesRepository(KsuEmploymentDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
