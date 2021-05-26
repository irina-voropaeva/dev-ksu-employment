using System.Collections.Generic;

namespace KsuEmployment.DataAccess.Entities
{
    public class Role : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public IList<Company> Companies { get; set; }
        public IList<Recruiter> Recruiters { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
