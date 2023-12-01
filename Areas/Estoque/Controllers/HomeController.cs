using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Area("Estoque")]
    public class HomeController : Controller
    {
        [Route("Estoque")]
        public ViewResult Index()
        {
            ViewData["Title"] = "Estoque";
            return View();
        }
    }
}
