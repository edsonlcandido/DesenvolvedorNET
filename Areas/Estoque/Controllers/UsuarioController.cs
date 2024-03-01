using DesenvolvedorNET.Models.Estoque;
using DesenvolvedorNET.ViewModels.Estoque;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Authorize]
    [Area("Estoque")]
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public UsuarioController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signManager = signInManager;
        }
        [AllowAnonymous]
        [Route("estoque/usuario/novo")]
        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View();
        }
        [AllowAnonymous]
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
                await _signManager.SignInAsync(user, false);
                return RedirectToAction("index", "home", new { area = "estoque" });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("estoque/usuario/login")]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("estoque/usuario/login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel model, string returnUrl="")
        {
            if (ModelState.IsValid)
            {         
                //verify if user email exists
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Usuário não encontrado!");
                    return View(model);
                }

                var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                          
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) )
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home", new { area = "estoque" });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login ou senha inválidos!");
                    return View(model);
                }
                
            }
            return View(model);
        }
        [AllowAnonymous]
        [Route("estoque/usuario/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("index", "home", new { area = "estoque" });
        }
    }
}
