using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class SpecificationViewModel
    {
        [Key]
         public int ID { get; set; }
        [Required]
        public string SpecificationName { get; set; }

    }
}
