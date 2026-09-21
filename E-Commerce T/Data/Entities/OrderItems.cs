namespace E_Commerce_T.Data.Entities
{
    public class OrderItems
    {
        public long id { get; set; }
        public long orderId { get; set; }
        public Order order { get; set; }
        public long productVariantId { get; set; }
        public ProductVariant productVariant { get; set; }
        public int quantity { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public decimal Price { get; set; }
    }
}
