using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetotg.Models;

namespace projetotg.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userMgr {get;}
        private SignInManager<AppUser> _singInMgt {get;}

        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                ILogger<AccountController> logger)
            {
                _userMgr = userManager;
                _singInMgt = signInManager;
                _logger = logger;
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
                    user.FirstName = FirtName;
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
        public async Task<IActionResult> PasswordReset(string Email, string Username,string PasswordHash, 
                                                        string NewPassword)
        {
            try
            {   
                Console.WriteLine(NewPassword);
                AppUser user = await _userMgr.FindByEmailAsync(Email);
                _logger.LogWarning("usuario "+ user.UserName);
                if(user == null)
                {
                    ViewBag.UserNotFound = "NotFound";
                }
                else
                {
                     var userToken = await _userMgr.GenerateUserTokenAsync(user,"Default","ResetPassword");
                     _logger.LogWarning("usuario Token" );
                    var resultResetPassword = await _userMgr.ResetPasswordAsync(user, userToken, NewPassword);

                    if (resultResetPassword.Succeeded){
                        return RedirectToAction("Home","Index");
                    }
                    return RedirectToAction("Account","Login");
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