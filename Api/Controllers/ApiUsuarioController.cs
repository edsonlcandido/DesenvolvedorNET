using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Api.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class ApiUsuarioController : ControllerBase
    {
        public ApiUsuarioController()
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            //get all Usuarios from database
            var list = UsuarioRepository.GetAll();
            //convert ienumerable to list
            List<Usuario> usuarios = list.Result.ToList();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            //get a Usuario by id from database
            var resul = UsuarioRepository.GetById(id);
            Usuario usuario = resul.Result;
            return Ok(usuario);
        }
        //PUT to update a Usuario
        [HttpPut("{id}")]
        public IActionResult Index(string id, [FromBody] Usuario usuario)
        {
            //update a Usuario
            UsuarioRepository.Update(usuario);
            return Ok();
        }
    }
}
