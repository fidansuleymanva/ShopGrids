namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class StartBannerAreaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public StartBannerAreaController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _dataContext.StartBannerAreas.AsQueryable();
            var PaginationList = PaginationList<StartBannerArea>.Create(query, 3, page);
            return View(PaginationList );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StartBannerArea startBannerArea)
        {
            if (startBannerArea.FromFile.ContentType != "image/png" && startBannerArea.FromFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                return View();
            }
            if (startBannerArea.FromFile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                return View();
            }
            startBannerArea.Img = FileManager.SaveFile(_env.WebRootPath, "uploads/startbanner", startBannerArea.FromFile);
            _dataContext.StartBannerAreas.Add(startBannerArea);
            _dataContext.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            StartBannerArea startBannerArea = _dataContext.StartBannerAreas.Find(id);
            if (startBannerArea == null) return NotFound();
            return View(startBannerArea);
        }
        [HttpPost]
        public IActionResult Update(StartBannerArea startBannerArea)
        {
            StartBannerArea exsiststartBannerArea = _dataContext.StartBannerAreas.Find(startBannerArea.Id);
            if (exsiststartBannerArea == null) return View(exsiststartBannerArea);
            if (startBannerArea.FromFile != null)
            {

                if (startBannerArea.FromFile.ContentType != "image/png" && startBannerArea.FromFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (startBannerArea.FromFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/startbanner", startBannerArea.FromFile);
                FileManager.DeleteFile(_env.WebRootPath, "uploads/startbanner", exsiststartBannerArea.Img);
                exsiststartBannerArea.Img = name;
            }
            exsiststartBannerArea.Title1 = startBannerArea.Title1;
            exsiststartBannerArea.Title2 = startBannerArea.Title2;
            exsiststartBannerArea.Title3 = startBannerArea.Title3;
            exsiststartBannerArea.ButtonText = startBannerArea.ButtonText;
            exsiststartBannerArea.URL = startBannerArea.URL;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            StartBannerArea startBannerArea = _dataContext.StartBannerAreas.Find(id);
            if (startBannerArea == null) return NotFound();
            return View(startBannerArea);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            StartBannerArea startBannerArea = _dataContext.StartBannerAreas.Find(id);
            if (startBannerArea == null) return NotFound();
            if (startBannerArea.Img != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/startbanner", startBannerArea.Img);
            }

            _dataContext.StartBannerAreas.Remove(startBannerArea);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
