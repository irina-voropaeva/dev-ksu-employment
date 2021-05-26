using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Interfaces.Entities;

namespace KsuEmployment.Common.DTOS
{
    public class InvitationDTO : IEntity<int>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public VacancyDTO Vacancy { get; set; }
    }
}
