using System;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Interfaces.Entities;

namespace KsuEmployment.Common.DTOS
{
    public class EducationPeriodDTO : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int ResumeId { get; set; }

        public FacultyDTO Faculty { get; set; }
        public SchoolDTO School { get; set; }
    }
}
