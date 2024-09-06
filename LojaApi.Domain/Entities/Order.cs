using LojaApi.Domain.Enums;

namespace LojaApi.Domain.Entities
{
    public class Order
    {
        public Guid Id{ get; set; } = Guid.NewGuid();
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Open;
        public List<OrderItem> OrderItens { get; set; } = new List<OrderItem>();
    }
}
