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

    }
}
