namespace ShopGrids.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SliderController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public SliderController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _dataContext.Slider.AsQueryable();
            //List<Slider> sliderList = _dataContext.Slider.ToList();
            var PaginationList = PaginationList<Slider>.Create(query, 3, page);
            return View(PaginationList);

    
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Slider slider)
        //{
        //    if (slider.FromFile.ContentType != "image/png" && slider.FromFile.ContentType != "image/jpeg")
        //    {
        //        ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
        //        return View();
        //    }
        //    if (slider.FromFile.Length > 3145728)
        //    {
        //        ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
        //        return View();
        //    }
        //    slider.Img = FileManager.SaveFile(_env.WebRootPath, "uploads/sliders", slider.FromFile);
        //    _dataContext.Slider.Add(slider);
        //    _dataContext.SaveChanges();
        //    return RedirectToAction("index");

        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            if (slider.FromFile == null || slider.FromFile.Length == 0)
            {
                ModelState.AddModelError("FromFile", "Please select an image file.");
                return View(slider);
            }

            if (slider.FromFile.ContentType != "image/png" && slider.FromFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("FromFile", "Only PNG and JPEG image files are allowed.");
                return View(slider);
            }

            if (slider.FromFile.Length > 3145728)
            {
                ModelState.AddModelError("FromFile", "The image file size must be less than 3 MB.");
                return View(slider);
            }

            try
            {
                slider.Img = FileManager.SaveFile(_env.WebRootPath, "uploads/sliders", slider.FromFile);
                _dataContext.Slider.Add(slider);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during file upload or database operations.
                ModelState.AddModelError(string.Empty, "An error occurred while creating the slider.");
                return View(slider);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _dataContext.Slider.Find(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider existslider = _dataContext.Slider.Find(slider.Id);
            if (existslider == null) return View(existslider);
            if (slider.FromFile != null)
            {

                if (slider.FromFile.ContentType != "image/png" && slider.FromFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (slider.FromFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                string name = FileManager.SaveFile(_env.WebRootPath, "uploads/sliders", slider.FromFile);
                FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", existslider.Img);
                existslider.Img = name;
            }
            existslider.Title1 = slider.Title1;
            existslider.Title2 = slider.Title2;
            existslider.Title3 = slider.Title3;
            existslider.Description = slider.Description;
            existslider.SalePrice = slider.SalePrice;
            existslider.URL = slider.URL;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    Slider slider = _dataContext.Slider.Find(id);
        //    if (slider == null) return NotFound();
        //    return View(slider);
        //}
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    Slider slider = _dataContext.Slider.Find(id);
        //    if (slider == null) return NotFound();
        //    if (slider.Img != null)
        //    {
        //        FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", slider.Img);
        //    }

        //    _dataContext.Slider.Remove(slider);
        //    _dataContext.SaveChanges();
        //    return Ok();


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Slider slider = _dataContext.Slider.Find(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Slider slider = _dataContext.Slider.Find(id);
            if (slider == null) return NotFound();
            if (slider.Img != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/sliders", slider.Img);
            }

            _dataContext.Slider.Remove(slider);
            _dataContext.SaveChanges();

            // Redirect to the Index action to refresh the page
            return RedirectToAction("Index");
        }

    }
}

