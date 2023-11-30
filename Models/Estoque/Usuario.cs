using Microsoft.AspNetCore.Identity;

namespace DesenvolvedorNET.Models.Estoque
{
    public class Usuario : IdentityUser
    {
        public string Id { get; set; }
        public string Nome { get; set;}
        public string Password { get; set; }
    }
}
