using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Area("estoque")]
    [Route("estoque/[controller]")]
    public class FuncoesController : Controller
    {
        
        public IActionResult Index()
        {
            return RedirectToRoute(new {controller="home", action="index", area="" });
        }
    }
}
