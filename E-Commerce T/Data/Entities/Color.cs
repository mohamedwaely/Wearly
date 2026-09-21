namespace E_Commerce_T.Data.Entities
{
    public class Color
    {
        public long id { get; set; }
        public String name { get; set; }
        public string? hexCode { get; set; }
        public List<ProductVariant> products { get; set; }
    }
}
