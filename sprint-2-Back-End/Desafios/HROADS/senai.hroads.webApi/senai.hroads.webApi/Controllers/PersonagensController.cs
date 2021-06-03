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
    public class PersonagensController : ControllerBase
    {
        private IPersonagensRepository _personagensRepository { get; set; }

        public PersonagensController()
        {
            _personagensRepository = new PersonagensRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagensRepository.ListarTodos());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(PersonagensDomain novoPersonagem)
        {
            if (novoPersonagem.NomePersonagem == null)
            {
                return BadRequest("O nome do personagens é obrigatório!");
            }
            _personagensRepository.Cadastrar(novoPersonagem);

            return Created("http://localhost:5000/api/Habilidade", novoPersonagem);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PersonagensDomain personagemBuscado = _personagensRepository.BuscarPorId(id);

            if (personagemBuscado != null)
            {
                return Ok(personagemBuscado);
            }

            return NotFound("Nenhum personagem encontrado para o identificador informado");
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, PersonagensDomain personagemAtualizado)
        {
            PersonagensDomain personagemBuscado = _personagensRepository.BuscarPorId(id);

            if (personagemBuscado != null)
            {
                try
                {

                    _personagensRepository.Atualizar(id, personagemAtualizado);

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
                     mensagem = "Personagem não encontrado",
                     erro = true
                 }
             );
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PersonagensDomain personagemBuscado = _personagensRepository.BuscarPorId(id);

            if (personagemBuscado != null)
            {
                _personagensRepository.Deletar(id);

                return Ok($"O personagem {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum personagem encontrado para o identificador informado");
        }
    }
}
