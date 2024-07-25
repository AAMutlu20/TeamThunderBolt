using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EduAssignmentHub.Services;
using Microsoft.AspNetCore.Authentication;

namespace EduAssignmentHub.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Login()
        {
            return View();
        }
    }
}