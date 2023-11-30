using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers.Estoque
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Estoque/Usuario/Novo")]
        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View("~/Views/Estoque/Usuario/Novo.cshtml");
        }
        [HttpPost]
        [Route("Estoque/Usuario/Novo")]
        public async Task<IActionResult> Novo(IdentityUser model)
        {
            var result = await _userManager.CreateAsync(model, model.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("~/Views/Estoque/Usuario/Novo.cshtml", model);
        }
    }
}
