using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(10,ErrorMessage ="This {0} must be between {2} , {1}",MinimumLength =5)]
        [Display(Name = "Category name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
