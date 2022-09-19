using MAC.Data.Abstractions;

namespace MAC.Data.Entities
{
    public class Student : IGenericIdAbstraction
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Badge Badge { get; set; }   
    }
}
