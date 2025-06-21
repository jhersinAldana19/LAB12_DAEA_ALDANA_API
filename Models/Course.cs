using System.ComponentModel.DataAnnotations;

namespace LAB12_ALDANA_API.Models
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }

        [MaxLength(45)]
        public string Name { get; set; }

        public int Credit { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
