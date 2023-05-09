using System.ComponentModel.DataAnnotations;

namespace Eventmi.Core.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field '{0}' is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols")]
        public string Name { get; set; } = null!;
    }
}
