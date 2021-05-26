using KsuEmployment.Common.Interfaces.Entities;

namespace KsuEmployment.Common.DTOS
{
    public class ResumeLanguageDTO : IEntity<int>
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }

        public LanguageDTO Language { get; set; }
    }
}
