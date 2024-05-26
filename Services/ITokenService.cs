using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services
{
    public interface ITokenService
    {
        public string GenerateToken(Usuario usuario);
    }
}
