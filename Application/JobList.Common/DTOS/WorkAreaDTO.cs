using KsuEmployment.Common.Interfaces.Entities;

namespace KsuEmployment.Common.DTOS
{
    public class WorkAreaDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
