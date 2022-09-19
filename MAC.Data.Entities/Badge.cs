using MAC.Data.Abstractions;

namespace MAC.Data.Entities
{
    public class Badge : IGenericIdAbstraction
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
