using AutoMapper;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace KsuEmployment.DataAccess.Repositories
{
    public class CitiesRepository : Repository<City, int>, ICitiesRepository
    {
        public CitiesRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
