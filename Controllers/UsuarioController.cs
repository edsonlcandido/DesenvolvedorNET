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
            //throw new Exception("Teste");

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
            if (UsuarioRepository.GetById(id).Result == null)
            {
                Response.StatusCode = 404;
                return View("UsuarioNotFound", id);
            }

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
            UsuarioCreateViewModel usuarioCreateViewModel = new UsuarioCreateViewModel()
            {
                Title = "Usuário - criar"
            };
            return View("Create", usuarioCreateViewModel);
        }
        // POST: /Usuario/Create
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCreateViewModel usuarioCreateViewModel)
        {
            //create a new Guid for usuario id
            Usuario usuario = usuarioCreateViewModel.Usuario;
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
        // GET: /Usuario/Edit/5
        public ViewResult Edit(string id)
        {
            UsuarioEditViewModel usuarioEditViewModel = new UsuarioEditViewModel()
            {
                Usuario = UsuarioRepository.GetById(id).Result,
                Title = "Usuário - editar"
            };
            return View("Edit", usuarioEditViewModel);
        }
        // POST: /Usuario/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioEditViewModel usuarioEditViewModel)
        {
            usuarioEditViewModel.Title = "Usuário - editar";
            //create a new Guid for usuario id
            Usuario usuario = usuarioEditViewModel.Usuario;
            ModelState.Clear();
            //revalidate ModelState
            TryValidateModel(usuario);
            //validate usuario model 
            if (ModelState.IsValid)
            {
                int RowNum = await UsuarioRepository.Update(usuario);
                if (RowNum == 1)
                {
                    return RedirectToAction("details", new { id = usuario.Id });
                }
                return View("Edit");
            }
            return View("Edit");
        }
        // GET: /Usuario/Delete/5
        public ViewResult Delete(string id)
        {
            UsuarioDeleteViewModel usuarioDeleteViewModel = new UsuarioDeleteViewModel()
            {
                Usuario = UsuarioRepository.GetById(id).Result,
                Title = "Usuário - deletar"
            };
            return View("Delete", usuarioDeleteViewModel);
        }
        // POST: /Usuario/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(UsuarioDeleteViewModel usuarioDeleteViewModel)
        {
            usuarioDeleteViewModel.Title = "Usuário - deletar";
            //create a new Guid for usuario id
            Usuario usuario = usuarioDeleteViewModel.Usuario;

            await UsuarioRepository.Delete(usuario.Id);

            return Redirect("/usuario");
        }
    }
}

