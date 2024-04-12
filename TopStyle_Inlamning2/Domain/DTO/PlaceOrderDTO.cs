namespace TopStyle_Inlamning2.Domain.DTO
{
    public class PlaceOrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public List<int> Products { get; set; }
    }
}
