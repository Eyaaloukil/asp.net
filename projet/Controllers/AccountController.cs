using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace projet.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
            ClaimsIdentity identity=null;
            bool isAuthenticate=false;
            if(username=="admin" && password=="admin"){
                identity=new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name,username),
                     new Claim(ClaimTypes.PrimarySid,"1"),
                    new Claim(ClaimTypes.Role,"Admin")
                },CookieAuthenticationDefaults.AuthenticationScheme);
            isAuthenticate=true;
            }
            if(username=="demo" && password=="demo"){
                identity=new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,"User")
                },CookieAuthenticationDefaults.AuthenticationScheme);
            isAuthenticate=true;
            }
            if(isAuthenticate){
                var principal=new ClaimsPrincipal(identity);
                var login=HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
              if(username=="admin" && password=="a"){
                return RedirectToAction("Index","Home");}
                else if(username=="demo" && password=="d"){
                
                return RedirectToAction("Index","App");}

                }
            


            return View();

        }
    }
}