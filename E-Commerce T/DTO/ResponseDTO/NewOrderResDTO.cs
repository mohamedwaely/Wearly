namespace E_Commerce_T.DTO.ResponseDTO
{
    public class NewOrderResDTO
    {
        public long id;
        public string status;
        public DateTime orderedAt;
        public decimal totalAmount;
        public long itemCount;
    }
}
