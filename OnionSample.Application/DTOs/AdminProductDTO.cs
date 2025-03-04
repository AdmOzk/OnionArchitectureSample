namespace OnionSample.Application.DTOs
{
    public class AdminProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        // Admin can assign a seller.
        public int SellerId { get; set; }
        // Admin can update the status ("Approved", "Rejected", or "Pending")
        public string Status { get; set; }
    }
}
