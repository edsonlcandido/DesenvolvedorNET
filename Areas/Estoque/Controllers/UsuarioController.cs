using DesenvolvedorNET.Models.Estoque;
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

        [Route("estoque/usuario/novo")]
        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View();
        }
        [HttpPost]
        [Route("estoque/usuario/novo")]
        public async Task<IActionResult> Novo(Usuario model)
        {
            //verify if password and password confirm are equals
            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError("", "Senha e confirmação de senha não conferem!");
                return View(model);
            }

            IdentityUser user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);
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
        [Route("estoque/usuario/login")]
        public IActionResult Login()
        {
            return View("~/areas/estoque/views/usuario/novo.cshtml");
        }
    }
}
