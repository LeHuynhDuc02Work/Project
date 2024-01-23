using Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Post : BaseEntity
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "ShortDescription cannot exceed 500 characters")]
        public string ShortDescription { get; set; }
        [StringLength(1000, ErrorMessage = "Meta cannot exceed 1000 characters")]
        public string Meta { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }

        public Category Category { get; set; }
        public ICollection<PostTagMap> PostTags { get; set; }
    }
}
