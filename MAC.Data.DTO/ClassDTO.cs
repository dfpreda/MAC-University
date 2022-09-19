using System.Collections.Generic;

namespace MAC.Data.DTO
{
    public class ClassDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ClassGroupDTO> ClassGroups { get; set; }
    }
}
