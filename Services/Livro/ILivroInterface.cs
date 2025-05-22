using Biblioteca.Dtos.Livro;
using Biblioteca.Models;

namespace Biblioteca.Services.Livro
{
    public interface ILivroInterface
    {
        Task<List<LivroModel>> BuscarLivros();
        bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto);
        Task<LivroModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto);
        Task<LivroModel> BuscarLivroPorId(int? id);
        Task<LivroModel> Editar(LivroEdicaoDto livroEdicaoDto, IFormFile foto);
    }
}
