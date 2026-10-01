namespace E_Commerce_T.DTO.ResponseDTO
{
    public class NewCartItemRes
    {
        public long id { get; set; }
        public long cartId { get; set; }
        public long productVariantId { get; set; }
        public int quantity { get; set; }
    }
}
