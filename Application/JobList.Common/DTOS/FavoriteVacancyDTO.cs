using KsuEmployment.Common.Interfaces.Entities;

namespace KsuEmployment.Common.DTOS
{
    public class FavoriteVacancyDTO : IEntity<int>
    {
        public int Id { get; set; }
        public int EmployeerId { get; set; }
        public int VacancyId { get; set; }
    }
}
