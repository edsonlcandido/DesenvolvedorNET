using DesenvolvedorNET.Db;
using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using DesenvolvedorNET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    public class EmpregadoController : Controller
    {
        private DesenvolvedorNETContext _dbContext;
        //use dependency injection to get DesenvolvedorNETContext
        public EmpregadoController(DesenvolvedorNETContext context)
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
            return View(empregadoCreateViewModel);
        }

    }
}
