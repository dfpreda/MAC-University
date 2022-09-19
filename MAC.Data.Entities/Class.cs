using MAC.Data.Abstractions;
using System.Collections.Generic;

namespace MAC.Data.Entities
{
    public class Class : IGenericIdAbstraction
    {
        public Class() {
            ClassGroups = new HashSet<ClassGroup>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassGroup> ClassGroups { get; set; }
    }
}
