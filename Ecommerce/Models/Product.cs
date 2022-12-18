using Ecommerce.Data;
using Ecommerce.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Product : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ProductColor ProductColor { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Categories { get; set; }

    }
}
