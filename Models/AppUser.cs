namespace ShopGrids.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100, ErrorMessage = "FullName is too long!")]
        public string FullName { get; set; }
    }
}
