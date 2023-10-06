using DesenvolvedorNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesenvolvedorNET.Pages.Usuario
{
    public class _id_Model : PageModel
    {
        private string _title = "Usuário - detalhes";
        public string Title
        {
            get { return _title; }
        }
        public Models.Usuario Usuario { get; set; }
        public async Task OnGetAsync(string id)
        {
            var httpClient = new System.Net.Http.HttpClient();
            Uri newUri = new UriBuilder(Request.Scheme, Request.Host.Host, (int)Request.Host.Port).Uri;
            httpClient.BaseAddress = newUri;
            Usuario = await httpClient.GetFromJsonAsync<DesenvolvedorNET.Models.Usuario>($@"/api/usuario/{id}");
        }
    }
}
