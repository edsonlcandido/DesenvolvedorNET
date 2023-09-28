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
        public UsuarioModel Usuario { get; set; }
        public async Task OnGetAsync(string id)
        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new System.Uri("http://localhost:5064");
            Usuario = await httpClient.GetFromJsonAsync<DesenvolvedorNET.Models.UsuarioModel>($@"/api/usuario/{id}");
        }
    }
}
