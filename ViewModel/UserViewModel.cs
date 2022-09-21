using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsStudent { get; set; } = true; 
        public bool IsActive { get; set; } = true;
    }
}
