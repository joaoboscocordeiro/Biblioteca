using AutoMapper;
using Biblioteca.Data;
using Biblioteca.Dtos;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private string _caminhoServidor;

        public LivroService(AppDbContext context, IWebHostEnvironment sistema, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _caminhoServidor = sistema.WebRootPath;
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

        public async Task<LivrosModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto)
        {
            try
            {
                var codigoUnico = Guid.NewGuid().ToString();
                var nomeImage = foto.FileName.Replace(" ","").ToLower() + codigoUnico + livroCriacaoDto.ISBN + ".png";

                string caminhoImage = _caminhoServidor + "\\Imagem\\";

                if (!Directory.Exists(caminhoImage))
                {
                    Directory.CreateDirectory(caminhoImage);
                }

                using (var stream = System.IO.File.Create(caminhoImage + nomeImage))
                {
                    foto.CopyToAsync(stream).Wait();
                }

                //var livro = new LivrosModel
                //{
                //    Titulo = livroCriacaoDto.Titulo,
                //    Autor = livroCriacaoDto.Autor,
                //    Descricao = livroCriacaoDto.Descricao,
                //    Capa = nomeImage,
                //    ISBN = livroCriacaoDto.ISBN,
                //    Genero = livroCriacaoDto.Genero,
                //    AnoPublicacao = livroCriacaoDto.AnoPublicacao,
                //    QuantidadeEstoque = livroCriacaoDto.QuantidadeEstoque
                //};

                var livro = _mapper.Map<LivrosModel>(livroCriacaoDto);
                livro.Capa = nomeImage;

                _context.Add(livro);
                await _context.SaveChangesAsync();

                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto)
        {
            try
            {
                var livroDB = _context.Livros.FirstOrDefault(livro => livro.ISBN == livroCriacaoDto.ISBN);

                if (livroDB != null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }
    }
}
