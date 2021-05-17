using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace JobList.DataAccess.Repositories
{
    public class ExperiencesRepository : Repository<Experience, int>, IExperiencesRepository
    {
        public ExperiencesRepository(KsuEmploymentDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
