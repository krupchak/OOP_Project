using System.ComponentModel.DataAnnotations;

namespace Zoo_EF.Models
{
    public class Owners
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string? Address { get; set; }

        public List<Animals> Animals { get; set; }
    }
}