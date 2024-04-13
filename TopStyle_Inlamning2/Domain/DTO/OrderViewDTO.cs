namespace TopStyle_Inlamning2.Domain.DTO
{
    public class OrderViewDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
