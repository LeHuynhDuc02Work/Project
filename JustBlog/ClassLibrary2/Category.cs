using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}