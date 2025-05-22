using AutoMapper;
using Biblioteca.Dtos.Livro;
using Biblioteca.Models;

namespace Biblioteca.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<LivroCriacaoDto, LivroModel>();
            CreateMap<LivroModel, LivroEdicaoDto>();
            CreateMap<LivroEdicaoDto, LivroModel>();
        }
    }
}
