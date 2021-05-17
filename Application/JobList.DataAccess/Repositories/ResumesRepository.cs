using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace JobList.DataAccess.Repositories
{
    public class ResumesRepository : Repository<Resume, int>, IResumesRepository
    {
        public ResumesRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
