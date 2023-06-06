namespace DapperASPNetCore.Entities
{
    public class Animals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public int OwnerId { get; set; }
        public int AnimalTypeId { get; set; }
    }
}
