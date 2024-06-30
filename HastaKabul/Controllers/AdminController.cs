using Microsoft.AspNetCore.Mvc;

namespace HastaKabul.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
