using MAC.Data.Abstractions;
using System.Collections.Generic;

namespace MAC.Data.Entities
{
    public class Group : IGenericIdAbstraction
    {
        public Group()
        {
            Students = new HashSet<Student>();
            ClassGroups = new HashSet<ClassGroup>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ClassGroup> ClassGroups { get; set; }
    }
}
