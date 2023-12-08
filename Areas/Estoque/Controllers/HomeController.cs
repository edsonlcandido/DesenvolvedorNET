using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Authorize]
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
