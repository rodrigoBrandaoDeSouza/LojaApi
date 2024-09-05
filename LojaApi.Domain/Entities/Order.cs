namespace LojaApi.Domain.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
