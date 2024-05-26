using AuthenticationAPI.Data.Dtos;
using AuthenticationAPI.Models;
using AutoMapper;

namespace AuthenticationAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
