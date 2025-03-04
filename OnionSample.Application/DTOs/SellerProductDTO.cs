namespace OnionSample.Application.DTOs
{
    public class SellerProductDto
    {
        // When creating a new product, ProductId can be null.
        public int? ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
