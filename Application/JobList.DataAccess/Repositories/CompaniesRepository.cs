using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace JobList.DataAccess.Repositories
{
    public class CompaniesRepository : Repository<Company, int>, ICompaniesRepository
    {
        public CompaniesRepository(KsuEmploymentDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }   
    }
}
