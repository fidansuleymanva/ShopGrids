namespace ShopGrids.Models
{
    public class SmallBanner
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title2 { get; set; }
        public double SalePrice { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Image size is too much!")]
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }

    }
}
