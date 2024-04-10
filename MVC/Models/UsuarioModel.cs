using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UsuarioModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo nome não pode estar vazio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email não pode estar vazio.")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha não pode estar vazio.")]
        public string Senha { get; set; }

        public string? UrlImagem { get; set; }

        [Required(ErrorMessage = "O campo cnpj não pode estar vazio.")]
        public string Cnpj { get; set; }

        [Required]
        public bool IsFornecedor { get; set; }
    }
}