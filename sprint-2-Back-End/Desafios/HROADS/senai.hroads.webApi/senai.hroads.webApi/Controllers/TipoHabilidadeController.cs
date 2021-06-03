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
    public class TipoHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }
        public TipoHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodos());
        }

        [Authorize(Roles = "2")]

        [HttpPost]
        public IActionResult Post(TipoHabilidadeDomain novoTipoHabilidade)
        {
            if (novoTipoHabilidade.NomeTipo == null)
            {
                return BadRequest("O nome do tipo de habilidade é obrigatório!");
            }
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            return Created("http://localhost:5000/api/TipoHabilidade", novoTipoHabilidade);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoHabilidadeDomain tipoHabilidadeBuscado = _tipoHabilidadeRepository.BuscarPorId(id);

            if (tipoHabilidadeBuscado != null)
            {
                return Ok(tipoHabilidadeBuscado);
            }

            return NotFound("Nenhum tipo de habilidade encontrado para o identificador informado");
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidadeDomain tipoHabilidadeAtualizado)
        {
            TipoHabilidadeDomain tipoHabilidadeBuscado = _tipoHabilidadeRepository.BuscarPorId(id);

            if (tipoHabilidadeBuscado != null)
            {
                try
                {

                    _tipoHabilidadeRepository.Atualizar(id, tipoHabilidadeAtualizado);

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
                     mensagem = "Tipo de Habilidade não encontrado",
                     erro = true
                 }
             );
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoHabilidadeDomain tipoHabilidadeBuscado = _tipoHabilidadeRepository.BuscarPorId(id);

            if (tipoHabilidadeBuscado != null)
            {
                _tipoHabilidadeRepository.Deletar(id);

                return Ok($"O tipo de Habilidade {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de Habilidade encontrado para o identificador informado");
        }
    }
}
