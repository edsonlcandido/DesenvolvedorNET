﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DesenvolvedorNET.Models
{
    public class Empregado
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set;}
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }
    }
}
