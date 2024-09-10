using Microsoft.AspNetCore.Mvc;

namespace ContosoUniTARgv23.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
