namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SmallBannerController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public SmallBannerController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _dataContext.SmallBanners.AsQueryable();
            var PaginationList = PaginationList<SmallBanner>.Create(query, 3, page);
            return View(PaginationList);
         }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SmallBanner smallBanner)
        {
            if (smallBanner.FormFile.ContentType != "image/png" && smallBanner.FormFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                return View();
            }
            if (smallBanner.FormFile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                return View();
            }
            smallBanner.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/smallbanner", smallBanner.FormFile);
            _dataContext.SmallBanners.Add(smallBanner);
            _dataContext.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            SmallBanner smallBanner = _dataContext.SmallBanners.Find(id);
            if (smallBanner == null) return NotFound();
            return View(smallBanner);
        }
        [HttpPost]
        public IActionResult Update(SmallBanner smallBanner)
        {
            SmallBanner existsmall = _dataContext.SmallBanners.Find(smallBanner.Id);
            if (existsmall == null) return View(existsmall);
            if (smallBanner.FormFile != null)
            {

                if (smallBanner.FormFile.ContentType != "image/png" && smallBanner.FormFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (smallBanner.FormFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/smallbanner", smallBanner.FormFile);
                FileManager.DeleteFile(_env.WebRootPath, "uploads/smallbanner", existsmall.Image);
                existsmall.Image = name;
            }
            existsmall.Title1 = smallBanner.Title1;
            existsmall.Title2 = smallBanner.Title2;
            existsmall.SalePrice = smallBanner.SalePrice;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            SmallBanner smallBanner= _dataContext.SmallBanners.Find(id);
            if (smallBanner == null) return NotFound();
            return View(smallBanner);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            SmallBanner smallBanner = _dataContext.SmallBanners.Find(id);
            if (smallBanner == null) return NotFound();
            if (smallBanner.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", smallBanner.Image);
            }

            _dataContext.SmallBanners.Remove(smallBanner);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
