using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeUsuarioController : ControllerBase
    {
        private ITipoDeUsuarioRepository _tipoDeUsuarioRepository { get; set; }

        public TipoDeUsuarioController()
        {
            _tipoDeUsuarioRepository = new TipoDeUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoDeUsuarioRepository.ListarTodos());
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(TipoDeUsuarioDomain novoTipoDeUsuario)
        {
            if (novoTipoDeUsuario.nomeTipoUsuario == null)
            {
                return BadRequest("O nome do tipo de usuario é obrigatório!");
            }
            _tipoDeUsuarioRepository.Cadastrar(novoTipoDeUsuario);

            return Created("http://localhost:5000/api/TipoDeUsuario", novoTipoDeUsuario);
        }

        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoDeUsuarioDomain tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(id);

            if (tipoDeUsuarioBuscado != null)
            {
                return Ok(tipoDeUsuarioBuscado);
            }

            return NotFound("Nenhum tipo de usuario encontrado para o identificador informado");
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoDeUsuarioDomain tipoDeUsuarioAtualizado)
        {
            TipoDeUsuarioDomain tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(id);

            if (tipoDeUsuarioBuscado != null)
            {
                try
                {

                    _tipoDeUsuarioRepository.Atualizar(id, tipoDeUsuarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }
            return NotFound
             (
                 new
                 {
                     mensagem = "Tipo de Usuario não encontrado",
                     erro = true
                 }
             );
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoDeUsuarioDomain tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(id);

            if (tipoDeUsuarioBuscado != null)
            {
                _tipoDeUsuarioRepository.Deletar(id);

                return Ok($"O tipo de Usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de Usuario encontrado para o identificador informado");
        }
    }
}
