using System.ComponentModel.DataAnnotations;

namespace TODOList.DTO
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}