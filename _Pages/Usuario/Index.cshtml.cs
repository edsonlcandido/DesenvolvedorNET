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
        public DesenvolvedorNET.Models.Usuario[] Usuarios { get; set; }

        public string Title
        {
            get { return _title; }
        }
        public async Task OnGetAsync()
        {
            HttpClient httpClient = new System.Net.Http.HttpClient();
            Uri newUri = new UriBuilder(Request.Scheme, Request.Host.Host, (int)Request.Host.Port).Uri;
            httpClient.BaseAddress = newUri;
            Usuarios = await httpClient.GetFromJsonAsync <DesenvolvedorNET.Models.Usuario[]>("/api/usuario");
        }
    }
}
