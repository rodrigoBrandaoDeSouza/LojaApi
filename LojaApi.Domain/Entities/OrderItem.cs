namespace LojaApi.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(int quantity)
        {
            Quantity = quantity;
        }

        public Guid OrderItemId { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
    }
}
