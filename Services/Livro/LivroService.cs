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

        public async Task<LivroModel> BuscarLivroPorId(int? id)
        {
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LivroModel>> BuscarLivros()
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

        public async Task<LivroModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto)
        {
            try
            {
                var nomeImagem = GeraCaminhoArquivo(foto);

                var livro = _mapper.Map<LivroModel>(livroCriacaoDto);
                livro.Capa = nomeImagem;

                _context.Add(livro);
                await _context.SaveChangesAsync();

                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroModel> Editar(LivroEdicaoDto livroEdicaoDto, IFormFile foto)
        {
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == livroEdicaoDto.Id);

                var nomeCaminhoImagem = "";
                if (foto != null)
                {
                    string caminhoCapaExistente = _caminhoServidor + "\\Imagem\\" + livro.Capa;

                    if (File.Exists(caminhoCapaExistente))
                    {
                        File.Delete(caminhoCapaExistente);
                    }

                    nomeCaminhoImagem = GeraCaminhoArquivo(foto);
                }

                var livroModel = _mapper.Map<LivroModel>(livroEdicaoDto);

                if (nomeCaminhoImagem != "")
                {
                    livroModel.Capa = nomeCaminhoImagem;
                }
                else
                {
                    livroModel.Capa = livro.Capa;
                }

                livroModel.DataAlteracao = DateTime.Now;

                _context.Update(livroModel);
                await _context.SaveChangesAsync();

                return livroModel;
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

        public string GeraCaminhoArquivo(IFormFile foto)
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var nomeImage = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png";

            string caminhoImage = _caminhoServidor + "\\Imagem\\";

            if (!Directory.Exists(caminhoImage))
            {
                Directory.CreateDirectory(caminhoImage);
            }

            using (var stream = System.IO.File.Create(caminhoImage + nomeImage))
            {
                foto.CopyToAsync(stream).Wait();
            }

            return nomeImage;
        }
    }
}
