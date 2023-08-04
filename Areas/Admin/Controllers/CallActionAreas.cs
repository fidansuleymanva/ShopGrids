namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CallActionAreaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public CallActionAreaController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _dataContext.CallActionAreas.AsQueryable();
            var PaginationList = PaginationList<CallActionArea>.Create(query, 3, page);
            return View(PaginationList );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CallActionArea callActionArea)
        {
            if (!ModelState.IsValid) return View();
            _dataContext.Add(callActionArea);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CallActionArea callActionArea = _dataContext.CallActionAreas.FirstOrDefault(x => x.Id == id);
            if (callActionArea == null) return View();
            return View(callActionArea);
        }
        [HttpPost]
        public IActionResult Update(CallActionArea callActionArea)
        {
            if (callActionArea is null) return View();

            CallActionArea exsistcallActionArea = _dataContext.CallActionAreas.FirstOrDefault(x => x.Id == callActionArea.Id);
            if (exsistcallActionArea == null) return View();
            if (!ModelState.IsValid) return View(exsistcallActionArea);

            exsistcallActionArea.Title1 = callActionArea.Title1;
            exsistcallActionArea.Title2 = callActionArea.Title2;
            exsistcallActionArea.URL = callActionArea.URL;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            CallActionArea callActionArea = _dataContext.CallActionAreas.FirstOrDefault(x => x.Id == id);
            _dataContext.CallActionAreas.Remove(callActionArea);
            _dataContext.SaveChanges();
            return View(callActionArea);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            CallActionArea callActionArea = _dataContext.CallActionAreas.Find(id);
            if (callActionArea == null) return View();

            _dataContext.CallActionAreas.Remove(callActionArea);
            _dataContext.SaveChanges();
            return Ok();


        }
    }
}
