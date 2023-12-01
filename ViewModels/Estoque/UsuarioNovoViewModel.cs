using Microsoft.AspNetCore.Identity;

namespace DesenvolvedorNET.ViewModels.Estoque
{
    public class UsuarioNovoViewModel
    {
        public IdentityUser identityUser { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
