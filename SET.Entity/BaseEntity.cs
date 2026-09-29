using System.ComponentModel.DataAnnotations;

namespace SET.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedByProgram { get; set; }
        public string? ModifiedByProgram { get; set; }
    }
}