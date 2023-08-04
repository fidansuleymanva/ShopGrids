//namespace ShopGrids.Areas.Admin.Services
//{
//    public class LayoutService
//    {
//        private readonly UserManager<AppUser> _userManager;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public LayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
//        {
//            _userManager = userManager;
//            _httpContextAccessor = httpContextAccessor;

//        }
//        public async Task<AppUser> GetUser()
//        {
//            AppUser appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
//            return appUser;
//        }
//    }
//}
namespace ShopGrids.Areas.Admin.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser> GetUser()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                // Kullanıcı adı bulunamadıysa veya boşsa null döndür
                return null;
            }

            AppUser appUser = await _userManager.FindByNameAsync(userName);
            return appUser;
        }

    }
}