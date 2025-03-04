namespace OnionSample.Domain.Entities
{
    public enum ProductStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        // SellerId is now nullable so that an admin can assign one later.
        public int? SellerId { get; set; }
        // Default status is Pending (needs admin approval)
        public ProductStatus Status { get; set; } = ProductStatus.Pending;
    }
}
