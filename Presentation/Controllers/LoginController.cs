using DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO dto)
        {
            try
            {
                dto = _userService.Login(dto);
                Authenticate(dto);
                return RedirectToAction("Home", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Create(dto);
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }

        private void Authenticate(UserDTO dto)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", dto.Id.ToString()),
                new Claim("Username", dto.Username),
                new Claim(ClaimTypes.Role, dto.RoleName),
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie");
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}