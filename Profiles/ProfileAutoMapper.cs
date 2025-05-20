using AutoMapper;
using Biblioteca.Dtos;
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
