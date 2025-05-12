using Biblioteca.Data;
using Biblioteca.Dtos;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LivrosModel>> BuscarLivros()
        {
            try
            {
                return await _context.Livros.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<LivrosModel> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
