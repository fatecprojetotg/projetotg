using System;
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
        public async Task<IActionResult> Logout()
        {
            await _singInMgt.SignOutAsync();
            return RedirectToAction("Index","Home");
        } 
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string PasswordHash)
        {
            var resultUser = await _userMgr.FindByEmailAsync(Email);
            if(resultUser != null)
            {
                var resultRequest = await _singInMgt.PasswordSignInAsync(resultUser.UserName, PasswordHash, false, false);

                if(resultRequest.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Message = "Senha Incorreta";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Email ou senha incorretas ou você ainda não tem cadastro";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string FirtName, string LastName,
                                                string Email, string UserName,string PasswordHash)
        {
            try
            {
                AppUser user = await _userMgr.FindByEmailAsync(Email) ;
                if(user == null)
                {
                    user = new AppUser();
                    user.FirtName = FirtName;
                    user.LastName = LastName;
                    user.UserName = UserName;
                    user.Email = Email;
                
                    IdentityResult result = await _userMgr.CreateAsync(user, PasswordHash);
                    if (result != null)
                    {
                        ViewBag.register = "Usuario foi Criado";
                    }
                    else
                    {
                         ViewBag.register = "Ocorreu um erro na criação, tente novamente mais tarde";
                        return View("Register");

                    }
                }
                else
                {
                    ViewBag.register = "Usuario já possui um cadastro, tente outro";
                    return View("Register");
                }
            }
            catch(Exception ex)
            {
                 ViewBag.register = ex.Message;
            }
            return View("Login");
        }
        [HttpGet]
        public IActionResult PasswordReset(){
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(string Email, string UserName,string OldPassword, 
                                                        string NewPassword)
        {
            try
            {
                AppUser user = await _userMgr.FindByEmailAsync(Email) ;
                if(user == null)
                {
                    ViewBag.UserNotFound = "NotFound";
                }
                else
                {
                    _userMgr.GenerateUserTokenAsync(user).Result
                    // _singInMgt
                    // _userMgr.ResetPasswordAsync()
                }
            }
            catch(Exception ex)
            {
                 ViewBag.register = ex.Message;
            }
            return View("Login");
            
        }
    }
}