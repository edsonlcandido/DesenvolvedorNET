using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["Title"] = "Desenvolvedor.NET";
            var md = System.IO.File.ReadAllText("README.md");
            var html = Markdig.Markdown.ToHtml(md);
            ViewData["html"]= html;
            return View();
        }
    }
}
