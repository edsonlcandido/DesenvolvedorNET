using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers.Estoque
{
    public class HomeController : Controller
    {
        [Route("Estoque")]
        public ViewResult Index()
        {
            ViewData["Title"] = "Estoque";
            return View("~/Views/Estoque/Index.cshtml");
        }
    }
}
