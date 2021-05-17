using AutoMapper;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;
using KsuEmployment.DataAccess.Data;

namespace JobList.DataAccess.Repositories
{
    public class FavoriteVacanciesRepository : Repository<FavoriteVacancy, int>, IFavoriteVacanciesRepository
    {
        public FavoriteVacanciesRepository(KsuEmploymentDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
