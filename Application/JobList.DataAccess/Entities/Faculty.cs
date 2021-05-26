using System.Collections.Generic;

namespace KsuEmployment.DataAccess.Entities
{
    public class Faculty : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public IList<EducationPeriod> EducationPeriods { get; set; }
    }
}
