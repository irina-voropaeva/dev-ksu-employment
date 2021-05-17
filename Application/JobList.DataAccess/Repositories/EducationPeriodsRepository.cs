using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace JobList.DataAccess.Repositories
{
    public class EducationPeriodsRepository : Repository<EducationPeriod, int>, IEducationPeriodsRepository
    {
        public EducationPeriodsRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
