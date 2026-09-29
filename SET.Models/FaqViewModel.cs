using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SET.Models
{
    public class FaqViewModel
    {
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "FAQ Question is required")]
        [DisplayName("FAQ Question")]
        [MaxLength(500)]
        public string FaqQuestion { get; set; } = null!;

        [Required(ErrorMessage = "FAQ Answer is required")]
        [DisplayName("FAQ Answer")]
        [MaxLength(5000)]
        public string FaqAnswer { get; set; } = null!;
    }
}
