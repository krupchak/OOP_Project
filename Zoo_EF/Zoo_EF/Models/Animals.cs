using System.ComponentModel.DataAnnotations;

namespace Zoo_EF.Models
{
    public class Animals
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Owners? OwnerId { get; set; }
        public AnimalTypes AnimalTypeId { get; set; }
    }
}
