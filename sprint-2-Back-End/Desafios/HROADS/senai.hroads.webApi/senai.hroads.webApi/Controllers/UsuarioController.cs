using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.ListarTodos());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            if (novoUsuario.email == null)
            {
                return BadRequest("O email é obrigatório!");
            }
            else if (novoUsuario.senha == null)
            {
                return BadRequest("A senha é obrigatória!");
            }

            _usuarioRepository.Cadastrar(novoUsuario);

            return Created("http://localhost:5000/api/Jogo", novoUsuario);
        }

        [Authorize]
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.idTipoDeUsuario.ToString()),
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("games-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(
                issuer: "InLock.webApi",
                audience: "InLock.webApi",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                return Ok(UsuarioBuscado);
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomain UsuarioAtualizado)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (UsuarioBuscado != null)
            {
                _usuarioRepository.Atualizar(id, UsuarioAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);

                return Ok($"O usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }
    }
}
