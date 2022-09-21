using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsStudent { get; set; }  
        public bool IsActive { get; set; }
    }
}
