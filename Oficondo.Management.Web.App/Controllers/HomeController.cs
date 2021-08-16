using Microsoft.AspNetCore.Mvc;

namespace Oficondo.Management.Web.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
