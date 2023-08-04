using Microsoft.AspNetCore.Mvc;

namespace ShopGrids.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(DataContext dataContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel memberRegisterViewModel)
        {
            if (!ModelState.IsValid) return View();

            var existingUser = await _userManager.FindByNameAsync(memberRegisterViewModel.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("UserName", "Username has already been taken!");
                return View();
            }

            var newMember = new AppUser
            {
                FullName = memberRegisterViewModel.FullName,
                UserName = memberRegisterViewModel.UserName,
            };

            var result = await _userManager.CreateAsync(newMember, memberRegisterViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(newMember, "Member");
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _signInManager.SignInAsync(newMember, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();  
        }
        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{
        //    return View();

        //}

    }
}
