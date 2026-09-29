using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SET.Models
{
    public class ExpenseViewModel
    {
        public Guid UniqueId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [DisplayName("Title")]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Amount is required")]
        [DisplayName("Amount")]
        [Range(0.01, 10000000.00, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [DisplayName("Category")]
        [MaxLength(50)]
        public string Category { get; set; } = null!;

        [DisplayName("Description")]
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
