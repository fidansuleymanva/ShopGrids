namespace ShopGrids.Models
{
    public class Trending_Product
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Image size is too much!")]
        public string? Image { get; set; }
        public double SalePrice { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title2 size is too much!")]
        public string Title2 { get; set; }
        public double CostPrice { get; set; }
        public double DiscountPrice { get; set; }
        [NotMapped]
        public IFormFile? FromFile { get; set; }

    }
}
