using Biblioteca.Data;
using Biblioteca.Dtos.Usuario;
using Biblioteca.Models;
using Biblioteca.Services.Autenticacao;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly IAutenticacaoInterface _autenticacaoInterface;

        public UsuarioService(AppDbContext context, IAutenticacaoInterface autenticacaoInterface)
        {
            _context = context;
            _autenticacaoInterface = autenticacaoInterface;
        }

        public async Task<List<UsuarioModel>> BuscarUsuario(int? id)
        {
            try
            {
                var registros = new List<UsuarioModel>();

                if (id != null)
                {
                    registros = await _context.Usuarios.Where(cliente => cliente.Perfil == 0).Include(e => e.Endereco).ToListAsync();
                }
                else
                {
                    registros = await _context.Usuarios.Where(funcionario => funcionario.Perfil != 0).Include(e => e.Endereco).ToListAsync();
                }

                return registros;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int? id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioDB => usuarioDB.Id == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioCriacaoDto> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            try
            {
                _autenticacaoInterface.CriarSenhaHash(usuarioCriacaoDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel
                {
                    NomeCompleto = usuarioCriacaoDto.NomeCompleto,
                    Usuario = usuarioCriacaoDto.Usuario,
                    Email = usuarioCriacaoDto.Email,
                    Perfil = usuarioCriacaoDto.Perfil,
                    Turno = usuarioCriacaoDto.Turno,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                var endereco = new EnderecoModel
                {
                    Logradouro = usuarioCriacaoDto.Logradouro,
                    Numero = usuarioCriacaoDto.Numero,
                    Bairro = usuarioCriacaoDto.Bairro,
                    Estado = usuarioCriacaoDto.Estado,
                    Complemento = usuarioCriacaoDto.Complemento,
                    CEP = usuarioCriacaoDto.CEP,
                    Usuario = usuario
                };

                usuario.Endereco = endereco;

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return usuarioCriacaoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> VerificaSeExisteUsuarioEEmail(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            try
            {
                var mesmoUsuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioDB => usuarioDB.Email == usuarioCriacaoDto.Email 
                || usuarioDB.Usuario == usuarioCriacaoDto.Usuario);

                if (mesmoUsuario == null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
