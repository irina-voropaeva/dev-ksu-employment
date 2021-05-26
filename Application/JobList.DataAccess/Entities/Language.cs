using System.Collections.Generic;

namespace KsuEmployment.DataAccess.Entities
{
    public class Language : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public IList<ResumeLanguage> ResumeLanguages { get; set; }
    }
}
