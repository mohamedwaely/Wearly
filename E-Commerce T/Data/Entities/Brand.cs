namespace E_Commerce_T.Data.Entities
{
    public class Brand
    {
        public long id { get; set; }
        public String name { get; set; }

        public List<Product> products { get; set; }
    }
}
