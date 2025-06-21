using System.ComponentModel.DataAnnotations;

namespace LAB12_ALDANA_API.Models
{
    public class Grade
    {
        [Key]
        public int IdGrade { get; set; }

        [MaxLength(45)]
        public string Name { get; set; }

        [MaxLength(45)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
