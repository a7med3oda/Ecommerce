using Ecommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Order : IBaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
