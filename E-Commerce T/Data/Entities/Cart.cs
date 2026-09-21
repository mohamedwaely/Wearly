namespace E_Commerce_T.Data.Entities
{
    public class Cart
    {
        public long id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public long userId { get; set; }
        public User user { get; set; }

        public List<CartItems> cartItems { get; set; }

    }
}
