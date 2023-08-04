namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ShippingController : Controller
    {

        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public ShippingController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _dataContext.Shippings.AsQueryable();
            var PaginationList = PaginationList<Shipping>.Create(query, 3, page);
            return View(PaginationList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Shipping shipping)
        {
            if (!ModelState.IsValid) return View();
            _dataContext.Add(shipping);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Shipping shipping = _dataContext.Shippings.FirstOrDefault(x => x.Id == id);
            if (shipping == null) return View();
            return View(shipping);
        }
        [HttpPost]
        public IActionResult Update(Shipping shipping)
        {
            if (shipping is null) return View();

            Shipping exsistshipping = _dataContext.Shippings.FirstOrDefault(x => x.Id == shipping.Id);
            if (exsistshipping == null) return View();
            if (!ModelState.IsValid) return View(exsistshipping);

            exsistshipping.Title1 = shipping.Title1;
            exsistshipping.Title2 = shipping.Title2;
            exsistshipping.Icon = shipping.Icon;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Shipping shipping = _dataContext.Shippings.FirstOrDefault(x => x.Id == id);
            _dataContext.Shippings.Remove(shipping);
            _dataContext.SaveChanges();
            return View(shipping);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Shipping shipping = _dataContext.Shippings.Find(id);
            if (shipping == null) return View();

            _dataContext.Shippings.Remove(shipping);
            _dataContext.SaveChanges();
            return Ok();


        }
    }
}
