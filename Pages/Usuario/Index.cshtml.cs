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
       
        private string _title    = "Usuario";
        public DesenvolvedorNET.Models.Usuario[] Usuarios { get; set; }

        public string Title
        {
            get { return _title; }
        }

        public async Task<DesenvolvedorNET.Models.Usuario[]> UsuariosFromJsonAsync()
        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new System.Uri("http://localhost:5064");
            var json = await httpClient.GetStringAsync("/api/usuario");

            return JsonSerializer.Deserialize<DesenvolvedorNET.Models.Usuario[]>(json);
        }

        public async Task OnGetAsync()

        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new System.Uri("http://localhost:5064");
            Usuarios = await httpClient.GetFromJsonAsync <DesenvolvedorNET.Models.Usuario[]>("/api/usuario");
        }
    }
}