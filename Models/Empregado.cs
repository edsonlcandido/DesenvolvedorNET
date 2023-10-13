

namespace DesenvolvedorNET.Models
{
    public class Empregado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set;}
        public Departamento Departamento { get; set; }
    }
}
