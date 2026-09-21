namespace E_Commerce_T.Data.Entities
{
    public class User
    {
        public long id { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String userName { get; set; }
        public DateTime createdAt { get; set; }
        public UserRole role { get; set; }

        public Cart cart { get; set; }
        public List<Order> orders { get; set; }
        public Address address { get; set; }
    }
}
