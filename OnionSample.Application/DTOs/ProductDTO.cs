namespace OnionSample.Application.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int SellerId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        // This will hold values such as "Pending", "Approved", or "Rejected"
        public string Status { get; set; }
    }
}
