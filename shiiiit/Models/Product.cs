namespace shiiiit.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? ProductName { get; set; }
        public string? Seller { get; set; }
        public string? ProductDescription { get; set; }
        public uint NumberOfPurchases { get; set; }
        public decimal? Price { get; set; }
        public uint NumberOfProducts { get; set; }
        public bool IsAvailable { get; set; }
        public Guid CategoryID { get; set; }    
    }
}
