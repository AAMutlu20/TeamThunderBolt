using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EduAssignmentHub.Services;
using Microsoft.AspNetCore.Authentication;

namespace EduAssignmentHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _authService.LoginAsync(username, password);
            if (result == "Login successful")
            {
                // Handle successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle failed login
                ModelState.AddModelError("", result);
                return View();
            }
        }
    }
}