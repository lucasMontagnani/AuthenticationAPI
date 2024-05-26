using AuthenticationAPI.Data.Dtos;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _cadastroService;

        public UsuarioController(IUsuarioService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost("CadastraUsuario")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            await _cadastroService.Cadastra(createUsuarioDto);
            return Ok("Usuário Cadastrado!");
        }

        [HttpPost("LoginUsuario")]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioDto loginUsuarioDto)
        {
            var token = await _cadastroService.Login(loginUsuarioDto);
            return Ok(token);
        }
    }
}
