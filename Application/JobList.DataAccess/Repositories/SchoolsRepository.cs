using AutoMapper;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Repositories;
using KsuEmployment.DataAccess.Data;

namespace KsuEmployment.DataAccess.Repositories
{
    public class SchoolsRepository : Repository<School, int>, ISchoolsRepository
    {
        public SchoolsRepository(KsuEmploymentDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
