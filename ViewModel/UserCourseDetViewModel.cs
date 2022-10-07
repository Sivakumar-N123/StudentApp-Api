using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class UserCourseDetViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string username { get; set; }

        public string Course { get; set; }
        public string Spec { get; set; }


    }
}
