using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class UserViewModel
    {
        public const string CustomerPrefix = "2022ST";

        [Key]
        public int Id { get; set; }

        public string CustomerId
        {
            get { return string.Concat(CustomerPrefix, Id); }
            set { }
        }

        public string UserName{ get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; } = "Password@123";
        public byte[]? ProfileImage { get; set; }
        public bool IsStudent { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public bool IsVerify { get; set; } = false; 

    }
}
