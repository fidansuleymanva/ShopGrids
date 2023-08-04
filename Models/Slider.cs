namespace ShopGrids.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Image size is too much!")]
        public string? Img { get; set; }
        public string URL { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 256, ErrorMessage = "Description size is too much!")]
        public string Description { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title2 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title3 { get; set; }
        public double SalePrice { get; set; }

        [NotMapped]
        public IFormFile? FromFile { get; set; }
    }
}
