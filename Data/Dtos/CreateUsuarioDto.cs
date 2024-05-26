using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set;}
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
