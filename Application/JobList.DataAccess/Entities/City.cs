using System.Collections.Generic;

namespace KsuEmployment.DataAccess.Entities
{
    public class City : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public IList<Employee> Employees { get; set; }
        public IList<Vacancy> Vacancies { get; set; }
    }
}
