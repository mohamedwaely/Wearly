namespace E_Commerce_T.DTO.ResponseDTO
{
    public class AuthResDTO
    {
        public long id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public long CartId { get; set; }
        public string token { get; set; }
    }
}
