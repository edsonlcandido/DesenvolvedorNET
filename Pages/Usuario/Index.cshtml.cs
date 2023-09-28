using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DesenvolvedorNET.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace DesenvolvedorNET.Pages.Usuario
{
    public class IndexModel : PageModel
    {
       
        private string _title    = "Usuários";
        public DesenvolvedorNET.Models.UsuarioModel[] Usuarios { get; set; }

        public string Title
        {
            get { return _title; }
        }
        public async Task OnGetAsync()
        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new System.Uri("http://localhost:5064");
            Usuarios = await httpClient.GetFromJsonAsync <DesenvolvedorNET.Models.UsuarioModel[]>("/api/usuario");
        }
    }
}
