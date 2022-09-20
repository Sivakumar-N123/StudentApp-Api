using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public bool IsStudent { get; set; }  
        public bool IsActive { get; set; }
    }
}
