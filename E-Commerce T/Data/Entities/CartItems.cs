namespace E_Commerce_T.Data.Entities
{
    public class CartItems
    {
        public long id { get; set; }
        public long cartId { get; set; }
        public Cart cart { get; set; }
        public long productVariantId { get; set; }
        public ProductVariant productVariant { get; set; }
        public int quantity { get; set; }
    }
}
