namespace E_Commerce_T.Data.Entities
{
    public class Order
    {
        public long id { get; set; }
        public DateTime orderedAt { get; set; }
        public DateTime updatedAt { get; set; }
        public OrderStatus status { get; set; } 
        public List<OrderItems> orderItems { get; set; }
        public long userId { get; set; }
        public User user { get; set; }
        public long AddressId { get; set; }
        public Address address { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
