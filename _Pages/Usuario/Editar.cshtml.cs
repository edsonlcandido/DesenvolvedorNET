using DesenvolvedorNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace DesenvolvedorNET.Pages.Usuario
{
    public class EditarModel : PageModel
    {
        private string _title = "Usuário - editar";
        public string Title
        {
            get { return _title; }
        }
        [BindProperty]
        public Models.Usuario Usuario { get; set; }
        public async Task OnGetAsync(string id)
        {
            var httpClient = new System.Net.Http.HttpClient();
            Uri newUri = new UriBuilder(Request.Scheme, Request.Host.Host, (int)Request.Host.Port).Uri;
            httpClient.BaseAddress = newUri;
            Usuario = await httpClient.GetFromJsonAsync<DesenvolvedorNET.Models.Usuario>($@"/api/usuario/{id}");
        }

        public async Task<IActionResult> OnPutAsync()
        {
            var httpClient = new System.Net.Http.HttpClient();
            Uri newUri = new UriBuilder(Request.Scheme, Request.Host.Host, (int)Request.Host.Port).Uri;
            httpClient.BaseAddress = newUri;
            var content = new StringContent(JsonSerializer.Serialize(Usuario), Encoding.UTF8, "application/json");
            var result = await httpClient.PutAsync($@"/api/usuario/{Usuario.Id}", content);
            return RedirectToPage("/usuario");
        }
    }
}
