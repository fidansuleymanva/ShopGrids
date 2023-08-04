using Microsoft.AspNetCore.Mvc;

namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class TrendingProductController : Controller
    {

        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public TrendingProductController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index( int page =1)
        {
            var query = _dataContext.TrendingProducts.AsQueryable();
            var PaginationList = PaginationList<Trending_Product>.Create(query, 3, page);
            return View(PaginationList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Trending_Product trending_Product )
        {
            if (trending_Product.FromFile.ContentType != "image/png" && trending_Product.FromFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                return View();
            }
            if (trending_Product.FromFile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                return View();
            }
            trending_Product.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/trendingproducts", trending_Product.FromFile);
            _dataContext.TrendingProducts.Add(trending_Product);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Trending_Product trending_Product = _dataContext.TrendingProducts.Find(id);
            if (trending_Product == null) return NotFound();
            return View(trending_Product);
        }
        [HttpPost]
        public IActionResult Update(Trending_Product trending_Product)
        {
            Trending_Product exsisttrending_Product = _dataContext.TrendingProducts.Find(trending_Product.Id);
            if (exsisttrending_Product == null) return View(exsisttrending_Product);
            if (trending_Product.FromFile != null)
            {

                if (trending_Product.FromFile.ContentType != "image/png" && trending_Product.FromFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (trending_Product.FromFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/trendingproducts", trending_Product.FromFile);
                FileManager.DeleteFile(_env.WebRootPath, "uploads/trendingproducts", exsisttrending_Product.Image);
                exsisttrending_Product.Image = name;
            }
            exsisttrending_Product.Title = trending_Product.Title;
            exsisttrending_Product.Title2 = trending_Product.Title2;
            exsisttrending_Product.SalePrice = trending_Product.SalePrice;
            exsisttrending_Product.CostPrice = trending_Product.CostPrice;
            exsisttrending_Product.DiscountPrice = trending_Product.DiscountPrice;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Trending_Product trending_Product = _dataContext.TrendingProducts.Find(id);
            if (trending_Product == null) return NotFound();
            return View(trending_Product);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Trending_Product trending_Product = _dataContext.TrendingProducts.Find(id);
            if (trending_Product == null) return NotFound();
            if (trending_Product.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/trendingproducts", trending_Product.Image);
            }

            _dataContext.TrendingProducts.Remove(trending_Product);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
