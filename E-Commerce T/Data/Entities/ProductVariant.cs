namespace E_Commerce_T.Data.Entities
{
    public class ProductVariant
    {
        public long id { get; set; }
        public long quantity { get; set; }
        public decimal price { get; set; }
        public decimal? discountPercentage { get; set; }
        public DateTime? discountStartDate { get; set; }
        public DateTime? discountEndDate { get; set; }

        public long productId { get; set; }
        public Product product { get; set; }
        public long sizeId { get; set; }
        public Size size { get; set; }
        public long colorId { get; set; }
        public Color color { get; set; }

        public bool isActive { get; set; }

    }
}
