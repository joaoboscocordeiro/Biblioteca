using Biblioteca.Models;

namespace Biblioteca.Services.Livro
{
    public interface ILivroInterface
    {
        Task<List<LivrosModel>> BuscarLivros();
    }
}
