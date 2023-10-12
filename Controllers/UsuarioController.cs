using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using DesenvolvedorNET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    public class UsuarioController : Controller
    {
        public ViewResult Index()
        {
            ViewData["Title"] = "Usuários";
            //get all Usuarios from database
            var list = UsuarioRepository.GetAll();
            //convert ienumerable to list
            List<Usuario> usuarios = list.Result.ToList();
            ViewData["Usuarios"] = usuarios;
            return View(usuarios);
        }
        // GET: /Usuario/Details/5
        public ViewResult Details(string id)
        {
            UsuarioDetailsViewModel usuarioViewModel = new UsuarioDetailsViewModel()
            {
                Usuario = UsuarioRepository.GetById(id).Result,
                Title = "Usuário - detalhes"
            };


            ViewBag.Title = "Usuário - detalhes";
            //get usuario from database by id
            var resul = UsuarioRepository.GetById(id);
            Usuario usuario = resul.Result;
            ViewData["Usuario"] = usuario;
            return View("Details", usuarioViewModel);
        }
        // GET: /Usuario/Create
        public ViewResult Create()
        {
            
            return View("Create");
        }
        // POST: /Usuario/Create
        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            //create a new Guid for usuario id
            string id = Guid.NewGuid().ToString();
            usuario.Id = id;
            ModelState.Clear();
            //revalidate ModelState
            TryValidateModel(usuario);

            //validate usuario model 
            if (ModelState.IsValid)
            {
                int RowNum = await UsuarioRepository.Insert(usuario);
                if (RowNum == 1)
                {
                    return RedirectToAction("details", new { id = usuario.Id });
                }
                return View("Create");
            }
            return View("Create");            
        }
    }
}
