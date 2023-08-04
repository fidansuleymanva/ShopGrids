namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SmallBanner2Controller : Controller
    {

        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public SmallBanner2Controller(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _dataContext.SmallBanners2.AsQueryable();
            var PaginationList = PaginationList<SmallBanner2>.Create(query, 3, page);
            return View(PaginationList); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SmallBanner2 smallBanner2)
        {
            if (!ModelState.IsValid) return View();
            _dataContext.Add(smallBanner2);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            SmallBanner2 smallBanner2 = _dataContext.SmallBanners2.FirstOrDefault(x => x.Id == id);
            if (smallBanner2 == null) return View();
            return View(smallBanner2);
        }
        [HttpPost]
        public IActionResult Update(SmallBanner2 smallBanners2)
        {
            if (smallBanners2 is null) return View();

            SmallBanner2 exsistSmall = _dataContext.SmallBanners2.FirstOrDefault(x => x.Id == smallBanners2.Id);
            if (exsistSmall == null) return View();
            if (!ModelState.IsValid) return View(exsistSmall);

            exsistSmall.Title1 = smallBanners2.Title1;
            exsistSmall.Title2 = smallBanners2.Title2;
            exsistSmall.URL = smallBanners2.URL;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            SmallBanner2 smallBanner2 = _dataContext.SmallBanners2.FirstOrDefault(x => x.Id == id);
            _dataContext.SmallBanners2.Remove(smallBanner2);
            _dataContext.SaveChanges();
            return View(smallBanner2);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            SmallBanner2 smallBanner2 = _dataContext.SmallBanners2.Find(id);
            if (smallBanner2 == null) return View();

            _dataContext.SmallBanners2.Remove(smallBanner2);
            _dataContext.SaveChanges();
            return Ok();


        }

    }
}
