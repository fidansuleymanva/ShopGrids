namespace ShopGrids.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Sliders = _dataContext.Slider.ToList(),
                SmallBanner = _dataContext.SmallBanners.ToList(),
                SmallBanner2 =_dataContext.SmallBanners2.ToList(),
                CallActionAreas = _dataContext.CallActionAreas.ToList(),
                StartBannerAreas = _dataContext.StartBannerAreas.ToList(),
                Shippings = _dataContext.Shippings.ToList(),
                TrendingProducts = _dataContext.TrendingProducts.ToList(),
            };
            return View(homeViewModel);
            
        }
      

       
    }
}