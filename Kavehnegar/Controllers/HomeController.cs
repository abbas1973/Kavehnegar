using Microsoft.AspNetCore.Mvc;

namespace Kavehnegar.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

    }
}