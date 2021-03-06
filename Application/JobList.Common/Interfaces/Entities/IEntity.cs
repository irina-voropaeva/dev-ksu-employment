
using System;

namespace KsuEmployment.Common.Interfaces.Entities
{
    public interface IEntity<TKey> where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}
