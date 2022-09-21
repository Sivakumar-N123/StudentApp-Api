using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class SpecificationViewModel
    {
        [Key]
         public Guid ID { get; set; }

        [Required]
        public string SpecificationName { get; set; }

    }
}
