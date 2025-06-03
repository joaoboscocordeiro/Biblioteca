using Biblioteca.Dtos.Usuario;
using Biblioteca.Models;

namespace Biblioteca.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<List<UsuarioModel>> BuscarUsuario(int? id);
        Task<bool> VerificaSeExisteUsuarioEEmail(UsuarioCriacaoDto usuarioCriacaoDto);
        Task<UsuarioCriacaoDto> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto);
        Task<UsuarioModel> BuscarUsuarioPorId(int? id);
    }
}
