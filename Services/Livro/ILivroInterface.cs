using Biblioteca.Dtos;
using Biblioteca.Models;

namespace Biblioteca.Services.Livro
{
    public interface ILivroInterface
    {
        Task<List<LivrosModel>> BuscarLivros();
        bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto);
        Task<LivrosModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto);
    }
}
