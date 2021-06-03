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
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.ListarTodos());
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(ClasseDomain novaClasse)
        {
            if (novaClasse.NomeClasse == null)
            {
                return BadRequest("O nome da classe é obrigatório!");
            }
            _classeRepository.Cadastrar(novaClasse);

            return Created("http://localhost:5000/api/Classe", novaClasse);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClasseDomain classeBuscado = _classeRepository.BuscarPorId(id);

            if (classeBuscado != null)
            {
                return Ok(classeBuscado);
            }

            return NotFound("Nenhuma classe encontrada para o identificador informado");
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClasseDomain classeAtualizada)
        {
            ClasseDomain classeBuscado = _classeRepository.BuscarPorId(id);

            if (classeBuscado != null)
            {
                try
                {

                    _classeRepository.Atualizar(id, classeAtualizada);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            } return NotFound
               (
                   new
                   {
                       mensagem = "Classe não encontrado",
                       erro = true
                   }
               );
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ClasseDomain classeBuscado = _classeRepository.BuscarPorId(id);

            if (classeBuscado != null)
            {
                _classeRepository.Deletar(id);

                return Ok($"A classe {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhuma classe encontrada para o identificador informado");
        }


    }
}
