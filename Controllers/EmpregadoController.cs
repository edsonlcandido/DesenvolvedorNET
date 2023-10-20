using DesenvolvedorNET.Db;
using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using DesenvolvedorNET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesenvolvedorNET.Controllers
{
    public class EmpregadoController : Controller
    {
        private EmpregadosContext _dbContext;
        //use dependency injection to get DesenvolvedorNETContext
        public EmpregadoController(EmpregadosContext context)
        {
            _dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            EmpregadoIndexViewModel empregadoIndexViewModel = new EmpregadoIndexViewModel()
            {
                Title = "Empregados"
            };
            //get all Empregados from database
            var list = await EmpregadoRepository.GetAll(_dbContext);
            //convert ienumerable to list
            empregadoIndexViewModel.Empregados = list.ToList();
            return View(empregadoIndexViewModel);
        }

        public async Task<IActionResult> Create()
        {
            EmpregadoCreateViewModel empregadoCreateViewModel = new EmpregadoCreateViewModel()
            {
                Title = "Empregado - novo"
            };
            //get all Departamentos from database
            var list = await DepartamentoRepository.GetAll(_dbContext);
            //convert ienumerable to list
            empregadoCreateViewModel.Departamentos = new List<SelectListItem>();
            foreach (var item in list.ToList())
            {
                empregadoCreateViewModel.Departamentos.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
            return View(empregadoCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpregadoCreateViewModel empregadoCreateViewModel)
        {
            Empregado empregado = new Empregado()
            {
                Nome = empregadoCreateViewModel.Empregado.Nome,
                Email = empregadoCreateViewModel.Empregado.Email,
                DepartamentoId = empregadoCreateViewModel.Empregado.DepartamentoId,
                Departamento = await DepartamentoRepository.GetById(empregadoCreateViewModel.Empregado.DepartamentoId, _dbContext)
            };
            ModelState.Clear();
            //revalidate ModelState
            TryValidateModel(empregado);
            if (ModelState.IsValid)
            {
                //convert viewmodel to model
                
                //add Empregado to database
                await EmpregadoRepository.Add(empregado, _dbContext);
                return RedirectToAction("Index","Empregado");
            }
            empregadoCreateViewModel.Title = "Empregado - novo";
            //get all Departamentos from database
            var list = await DepartamentoRepository.GetAll(_dbContext);
            //convert ienumerable to list
            empregadoCreateViewModel.Departamentos = new List<SelectListItem>();
            foreach (var item in list.ToList())
            {
                empregadoCreateViewModel.Departamentos.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
            return View(empregadoCreateViewModel);
        }

        public ViewResult Edit(int id)
        {
            EmpregadoEditViewModel empregadoEditViewModel = new EmpregadoEditViewModel()
            {
                Title = "Empregado - editar"
            };
            //get Empregado from database
            empregadoEditViewModel.Empregado = EmpregadoRepository.GetById(id, _dbContext).Result;
            //get all Departamentos from database
            var list = DepartamentoRepository.GetAll(_dbContext).Result;
            //convert ienumerable to list
            empregadoEditViewModel.Departamentos = new List<SelectListItem>();
            foreach (var item in list.ToList())
            {
                empregadoEditViewModel.Departamentos.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
            return View(empregadoEditViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            EmpregadoDetailsViewModel empregadoDetailsViewModel = new EmpregadoDetailsViewModel()
            {
                Title = "Empregado - detalhes"
            };
            //get Empregado from database
            empregadoDetailsViewModel.Empregado = await EmpregadoRepository.GetById(id, _dbContext);
            return View(empregadoDetailsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmpregadoEditViewModel empregadoEditViewModel)
        {
            Empregado empregado = new Empregado()
            {
                Id = empregadoEditViewModel.Empregado.Id,
                Nome = empregadoEditViewModel.Empregado.Nome,
                Email = empregadoEditViewModel.Empregado.Email,
                DepartamentoId = empregadoEditViewModel.Empregado.DepartamentoId,
                Departamento = await DepartamentoRepository.GetById(empregadoEditViewModel.Empregado.DepartamentoId, _dbContext)
            };
            ModelState.Clear();
            //revalidate ModelState
            TryValidateModel(empregado);
            if (ModelState.IsValid)
            {
                //convert viewmodel to model
                
                //update Empregado in database
                await EmpregadoRepository.Update(empregado, _dbContext);
                return RedirectToAction("Index", "Empregado");
            }
            empregadoEditViewModel.Title = "Empregado - editar";
            //get all Departamentos from database
            var list = await DepartamentoRepository.GetAll(_dbContext);
            //convert ienumerable to list
            empregadoEditViewModel.Departamentos = new List<SelectListItem>();
            foreach (var item in list.ToList())
            {
                empregadoEditViewModel.Departamentos.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
            return View(empregadoEditViewModel);
        }
    }
}
