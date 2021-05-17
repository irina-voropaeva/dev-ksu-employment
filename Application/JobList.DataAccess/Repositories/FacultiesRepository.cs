using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace JobList.DataAccess.Repositories
{
    public class FacultiesRepository : Repository<Faculty, int>, IFacultiesRepository
    {
        public FacultiesRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
