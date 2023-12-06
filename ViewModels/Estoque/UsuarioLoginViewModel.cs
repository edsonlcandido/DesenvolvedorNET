using System.ComponentModel.DataAnnotations;

namespace DesenvolvedorNET.ViewModels.Estoque
{
    public class UsuarioLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
