using DesenvolvedorNET.Db;
using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Api.Controllers
{
    [ApiController]
    [Route("api/empregado")]
    public class ApiEmpregadoController : ControllerBase
    {

        public ApiEmpregadoController()
        {
        }
        [HttpGet]
        public IActionResult Index([FromServices]EmpregadosContext context)
        {
            //get all Usuarios from database
            var list = EmpregadoRepository.GetAll(context);
            //convert ienumerable to list
            List<Empregado> empregados = list.Result.ToList();
            return Ok(empregados);
        }
        [HttpGet("{id}")]
        public IActionResult Index([FromServices] EmpregadosContext context, int id )
        {
            //get a Usuario by id from database
            var result = EmpregadoRepository.GetById(id, context);
            Empregado empregado = result.Result;
            if (empregado == null)
            {
                return NotFound("");
            }
            return Ok(empregado);
        }
        //PUT to update a Usuario
        [HttpPut("{id}")]
        public IActionResult Index([FromBody] Usuario usuario, string id)
        {
            //update a Usuario
            UsuarioRepository.Update(usuario);
            return Ok();
        }
    }
}
