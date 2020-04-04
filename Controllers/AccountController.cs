using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetotg.Models;

namespace projetotg.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userMgr {get;}
        private SignInManager<AppUser> _singInMgt {get;}

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
            {
                _userMgr = userManager;
                _singInMgt = signInManager;
            }

        // [HttpGet]
        // public async Task<IActionResult> Register()
        // {
        //     return View();
        // }
        // [HttpPost]
        // public async Task<IActionResult> Register()
        // {
        //     try
        //     {
                
        //     }
        //     catch
        //     {
                
        //     }
        // }
    }
}