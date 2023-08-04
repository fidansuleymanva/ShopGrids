namespace ShopGrids.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title size is too much!")]
        public string Title2 { get; set; }

    }
}
