using Biblioteca.Models;

namespace Biblioteca.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<List<UsuarioModel>> BuscarUsuario(int? id);
    }
}
