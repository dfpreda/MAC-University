using MAC.Data.Abstractions;

namespace MAC.Data.Entities
{
    public class ClassGroup
    {
        public int ClassId { get; set; }
        public int GroupId { get; set; }
        public Class Class { get; set; }    
        public Group Group { get; set; }
    }
}
