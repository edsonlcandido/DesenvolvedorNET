using DesenvolvedorNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
        }
        [HttpGet]
        public IActionResult Get()
        {
            //return JSON for Models/Usuario.cs
            List<Usuario> list = new List<Usuario>();   
            //new usuario
            Usuario usuario = new Usuario();
            usuario.Id = Guid.NewGuid();
            usuario.Nome = "Desenvolvedor.NET";
            //other usuario
            Usuario usuario2 = new Usuario();
            usuario2.Id = Guid.NewGuid();
            usuario2.Nome = "Desenvolvedor.NET 2";
            //add usuarios
            list.Add(usuario);
            list.Add(usuario2);
            //return list
            return Ok(list);
        }
    }
}
