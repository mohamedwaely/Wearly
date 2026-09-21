namespace E_Commerce_T.Data.Entities
{
    public class Size
    {
        public long id { get; set; }
        public String name { get; set; }
        public SizeType type { get; set; }

        public List<ProductVariant> products { get; set; }


    }
}
