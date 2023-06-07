using System.ComponentModel.DataAnnotations;

namespace Zoo_EF.Models
{
    public class AnimalTypes
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string AnimalType { get; set; }

        public List<Animals> Animals { get; set; }
    }
}