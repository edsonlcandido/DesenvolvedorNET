using System.ComponentModel.DataAnnotations;

namespace DesenvolvedorNET.Models
{

    public class Usuario
    {
        //the id is required and the range is the same of a GUId
        [Required, StringLength(36)]
        public string Id { get; set; }
        //use data anotations to set required min length 3 and max length 50
        [Required, MinLength(3), MaxLength(50)]
        public string Nome { get; set; }
    }
}
