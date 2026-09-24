namespace E_Commerce_T.Data.Entities
{
    public class Address
    {
        public long id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }

        public long userId { get; set; }
        public User user { get; set; }


    }
}
