using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(int quantity)
        {
            Quantity = quantity;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
