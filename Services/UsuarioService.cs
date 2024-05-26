using AuthenticationAPI.Data.Dtos;
using AuthenticationAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private ITokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task Cadastra(CreateUsuarioDto createUsuarioDto)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);
                IdentityResult resultado = await _userManager.CreateAsync(usuario, createUsuarioDto.Password);

                if (!resultado.Succeeded)
                {
                    throw new ApplicationException("Falha ao cadastrar usuário.");
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<string> Login(LoginUsuarioDto loginUsuarioDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(loginUsuarioDto.Username, loginUsuarioDto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao autenticar usuário.");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginUsuarioDto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
