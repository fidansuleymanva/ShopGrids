namespace ShopGrids.Models
{
    public class SmallBanner2
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title2 { get; set; }
        public string URL { get; set; }

    }
}
