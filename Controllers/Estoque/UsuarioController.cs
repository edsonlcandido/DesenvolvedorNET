using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers.Estoque
{
    public class UsuarioController : Controller
    {

        [Route("Estoque/Usuario/Novo")]
        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View("~/Views/Estoque/Usuario/Novo.cshtml");
        }
    }
}
