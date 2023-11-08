﻿using System.ComponentModel.DataAnnotations;

namespace Gran_Prix.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o telefone!")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o CPF!")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; }
    }
}
