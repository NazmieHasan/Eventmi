using System.ComponentModel.DataAnnotations;
using Eventmi.Infrastructure.Data.Models;

namespace Eventmi.Core.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field '{0}' is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols")]
        public string Name { get; set; } = null!;

        [Display(Name = "Start Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field '{0}' is required")]
        public DateTime Start { get; set; }

        [Display(Name = "End Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field '{0}' is required")]
        public DateTime End { get; set; }

        [Display(Name = "Place")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field '{0}' is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Field '{0}' must be between {2} and {1} symbols")]
        public string Place { get; set; } = null!;

        public int Category { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
