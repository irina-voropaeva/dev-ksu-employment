using AutoMapper;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace KsuEmployment.DataAccess.Repositories
{
    public class CompaniesRepository : Repository<Company, int>, ICompaniesRepository
    {
        public CompaniesRepository(KsuEmploymentDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }   
    }
}
