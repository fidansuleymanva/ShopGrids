namespace ShopGrids.Models
{
    public class CallActionArea
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title1 size is too much!")]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title2 size is too much!")]
        public string Title2 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title1 size is too much!")]
        public string Title3 { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Title1 size is too much!")]
        public string Title4 { get; set; }
        public string URL { get; set; }
    }
}
