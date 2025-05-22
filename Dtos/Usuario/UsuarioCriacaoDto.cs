using Biblioteca.Enums;
using Biblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dtos.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome completo!")]
        public string NomeCompleto { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o nome do usuario!")]
        public string Usuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite a situação!")]
        public bool Situacao { get; set; } = true;
        [Required(ErrorMessage = "Selecione um perfil!")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Selecione um turno!")]
        public TurnoEnum Turno { get; set; }
        [Required(ErrorMessage = "Digite a senha!"), MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres!")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirme a senha!"), Compare("Senha", ErrorMessage = "As senhas não coincidem!")]
        public string ConfirmaSenha { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o logradouro!")]
        public string Logradouro { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o bairro!")]
        public string Bairro { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o número!")]
        public string Numero { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o CEP!")]
        public string CEP { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o estado!")]
        public string Estado { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;
    }
}
