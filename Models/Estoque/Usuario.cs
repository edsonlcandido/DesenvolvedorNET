using Microsoft.AspNetCore.Identity;

namespace DesenvolvedorNET.Models.Estoque
{
    public class Usuario
    {
        public string Email { get; set;}
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
