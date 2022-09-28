using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class SpecificationViewModel
    {
        [Key]
         public Guid SpecificationId { get; set; }

        [Required]
        public string SpecificationName { get; set; }

    }
}
