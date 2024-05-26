using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario() : base()
        {
        }
        public DateTime DataNascimento { get; set; }
    }
}
