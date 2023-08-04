namespace ShopGrids.Models
{
    public class DataContext: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Slider> Slider { get; set; }   
        public DbSet<SmallBanner> SmallBanners { get; set; }
        public DbSet<SmallBanner2> SmallBanners2 { get; set; }
        public DbSet<CallActionArea> CallActionAreas { get; set; }
        public DbSet<StartBannerArea> StartBannerAreas { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Trending_Product> TrendingProducts { get; set; }
    }
}
