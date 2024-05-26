using AuthenticationAPI.Data.Dtos;

namespace AuthenticationAPI.Services
{
    public interface IUsuarioService
    {
        public Task Cadastra(CreateUsuarioDto createUsuarioDto);
        Task<string> Login(LoginUsuarioDto loginUsuarioDto);
    }
}
