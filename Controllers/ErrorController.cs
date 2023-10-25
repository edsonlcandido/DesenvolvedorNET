using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.Title = "Error 404";
                    ViewBag.ErrorMessage = "Desculpe, o conteudo procurado não está disponível";
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Title = "Error";
            ViewBag.ErrorMessage = "Desculpe, ocorreu um erro inesperado";
            ViewBag.ExceptionPath = exception.Path;
            ViewBag.ExceptionMessage = exception.Error.Message;
            ViewBag.StackTrace = exception.Error.StackTrace;
            return View("NotFound");
        }
    }
}
