using System;
using System.ComponentModel.DataAnnotations;
using KsuEmployment.Common.Interfaces.Entities;

namespace KsuEmployment.DataAccess.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey> where TKey : IComparable
    {
        [Key]
        public abstract TKey Id { get; set; }
    }
}
