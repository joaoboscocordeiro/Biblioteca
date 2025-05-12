using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Dtos
{
    public class LivroCriacaoDto
    {
        [Required(ErrorMessage = "Insira um título!")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira um autor!")]
        public string Autor { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira uma descrição!")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira uma capa!")]
        public string Capa { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira o ISBN!")]
        public string ISBN { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira um genero!")]
        public string Genero { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira o ano de publicação!")]
        public int AnoPublicacao { get; set; }
        [Required(ErrorMessage = "Insira uma quantidade!")]
        public int QuantidadeEstoque { get; set; }
    }
}
