using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Areas.Estoque.Controllers
{
    [Area("estoque")]
    [Route("estoque/[controller]")]
    public class FuncoesController : Controller
    {
        
        public IActionResult Index()
        {
            // cria um model de mock para trabalhar no render dessa view quero mostrar numa tabela 
            // os nomes das funcoes do RoleManager

            //List<IdentityRole> roles = new List<IdentityRole>();
            //// Adicione os objetos IdentityRole à lista
            //// Exemplo:
            //roles.Add(new IdentityRole("Administrador"));
            //roles.Add(new IdentityRole("Usuario"));

            var _roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();


            //get roles from RoleManager
            var roles = _roleManager.Roles.ToList();

            return View(roles);
            //return RedirectToRoute(new {controller="home", action="index", area="" });
        }
    }
}
