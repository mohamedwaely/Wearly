namespace E_Commerce_T.Data.Entities
{
    public class Category
    {
        public long id { get; set; }
        public String name { get; set; }
        public long? parentCategoryId { get; set; }
        public Category parentCategory { get; set; }
        public List<Category> subCategories { get; set; } = new();

        public List<Product> products { get; set; }
    }
}
