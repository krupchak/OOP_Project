namespace DapperASPNetCore.Entities
{
    public class Volunteers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AnimalId { get; set; }
        public int DepartmentId { get; set; }
    }
}
