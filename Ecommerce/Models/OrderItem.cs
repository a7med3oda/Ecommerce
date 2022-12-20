using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public int ProductId { get; set; }
        public virtual Order order { get; set; }
        public virtual Product product { get; set; }

    }
}
