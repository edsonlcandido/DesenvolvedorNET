using DesenvolvedorNET.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesenvolvedorNET.ViewModels
{
    public class EmpregadoEditViewModel
    {
        public string Title { get;  set; }
        public Empregado Empregado { get;  set; }
        public List<SelectListItem> Departamentos { get;  set; }
    }
}