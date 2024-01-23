using System.ComponentModel.DataAnnotations;

namespace Core.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        public string UrlSlug { get; set; }
    }
}