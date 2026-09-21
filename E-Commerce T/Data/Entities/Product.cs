namespace E_Commerce_T.Data.Entities
{
    public class Product
    {
        public long id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public long categoryId { get; set; }
        public Category category { get; set; }

        public long brandId { get; set; }
        public Brand brand { get; set; }

        public List<ProductVariant> productVariants { get; set; }


    }
}
