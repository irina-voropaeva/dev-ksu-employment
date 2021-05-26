using AutoMapper;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace KsuEmployment.DataAccess.Repositories
{
    public class ResumesRepository : Repository<Resume, int>, IResumesRepository
    {
        public ResumesRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
