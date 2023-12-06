using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Area("Estoque")]
    public class HomeController : Controller
    {
        [Route("estoque")]
        public ViewResult Index()
        {
            ViewData["Title"] = "Estoque";
            return View();
        }

        [Route("estoque/dashboard")]
        public ViewResult Dashboard()
        {
            ViewData["Title"] = "Dashboard";
            return View();
        }
    }
}
