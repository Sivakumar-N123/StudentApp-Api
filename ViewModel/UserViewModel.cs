using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; } = "Password@123";
        public byte[] ProfileImage { get; set; } 
        public bool IsStudent { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public bool IsVerify { get; set; } = false;

    }
}
