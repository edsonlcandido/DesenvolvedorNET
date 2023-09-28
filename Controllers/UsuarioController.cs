using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            //get all Usuarios from database
            var list = UsuarioRepository.GetAll();
            //convert ienumerable to list
            List<UsuarioModel> usuarios = list.Result.ToList();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            //get a Usuario by id from database
            var resul = UsuarioRepository.GetById(id);
            UsuarioModel usuario = resul.Result;
            return Ok(usuario);
        }
    }
}
