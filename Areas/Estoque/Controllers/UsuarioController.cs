using DesenvolvedorNET.ViewModels.Estoque;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Area("Estoque")]
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
            return View();
        }
        [HttpPost]
        [Route("Estoque/Usuario/Novo")]
        public async Task<IActionResult> Novo(UsuarioNovoViewModel model)
        {
            //verify if password and password confirm are equals
            if (model.identityUser.PasswordHash != model.PasswordConfirm)
            {
                ModelState.AddModelError("", "Senha e confirmação de senha não conferem!");
                return View(model);
            }

            var result = await _userManager.CreateAsync(model.identityUser, model.identityUser.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}
