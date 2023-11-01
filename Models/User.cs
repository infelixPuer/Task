using System.ComponentModel.DataAnnotations;

namespace CRUDTask.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d+$")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }
    }
}