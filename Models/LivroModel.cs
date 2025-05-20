using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Autor { get; set; } = string.Empty;
        [Required]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        public string Capa { get; set; } = string.Empty;
        [Required]
        public string ISBN { get; set; } = string.Empty;
        [Required]
        public string Genero { get; set; } = string.Empty;
        [Required]
        public int AnoPublicacao { get; set; }
        [Required]
        public int QuantidadeEstoque { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
