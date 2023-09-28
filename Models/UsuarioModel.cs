using System.ComponentModel.DataAnnotations;

namespace DesenvolvedorNET.Models
{

    public class UsuarioModel
    {
        //use data anotations to set key
        [Key]
        public string Id { get; set; }
        //use data anotations to set required min length 3 and max length 50
        [Required, MinLength(3), MaxLength(50)]
        public string Nome { get; set; }
    }
}
