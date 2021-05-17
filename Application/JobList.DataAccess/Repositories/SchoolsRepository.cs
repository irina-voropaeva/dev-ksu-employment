using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using JobList.DataAccess.Repositories;
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
