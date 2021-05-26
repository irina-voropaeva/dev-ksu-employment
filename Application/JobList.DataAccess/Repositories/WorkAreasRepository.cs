using AutoMapper;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Repositories;
using KsuEmployment.DataAccess.Data;

namespace KsuEmployment.DataAccess.Repositories
{
    public class WorkAreasRepository : Repository<WorkArea, int>, IWorkAreasRepository
    {
        public WorkAreasRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
