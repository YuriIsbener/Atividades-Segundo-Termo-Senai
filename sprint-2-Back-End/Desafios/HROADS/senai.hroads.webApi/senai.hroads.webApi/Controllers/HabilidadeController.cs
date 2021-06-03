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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.ListarTodos());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(HabilidadeDomain novaHabilidade)
        {
            if (novaHabilidade.NomeHabilidade == null)
            {
                return BadRequest("O nome da habilidade é obrigatório!");
            }
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return Created("http://localhost:5000/api/Habilidade", novaHabilidade);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            HabilidadeDomain habilidadeBuscado = _habilidadeRepository.BuscarPorId(id);

            if (habilidadeBuscado != null)
            {
                return Ok(habilidadeBuscado);
            }

            return NotFound("Nenhuma habilidade encontrada para o identificador informado");
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, HabilidadeDomain habilidadeAtualizada)
        {
            HabilidadeDomain habilidadeBuscado = _habilidadeRepository.BuscarPorId(id);

            if (habilidadeBuscado != null)
            {
                try
                {

                    _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

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
                     mensagem = "habilidade não encontrado",
                     erro = true
                 }
             );
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            HabilidadeDomain habilidadeBuscado = _habilidadeRepository.BuscarPorId(id);

            if (habilidadeBuscado != null)
            {
                _habilidadeRepository.Deletar(id);

                return Ok($"A habilidade {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhuma habilidade encontrada para o identificador informado");
        }
    }
}
