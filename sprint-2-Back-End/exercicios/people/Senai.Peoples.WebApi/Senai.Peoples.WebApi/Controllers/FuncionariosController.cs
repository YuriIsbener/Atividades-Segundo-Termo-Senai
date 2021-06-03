using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepository { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_funcionariosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(funcionariosDomain novoFuncionario)
        {
            if (novoFuncionario.Nome == null)
            {
                return BadRequest("O nome é obrigatório!");

            } else if (novoFuncionario.Sobrenome == null)
            {
                return BadRequest("O Sobrenome é obrigatório!");
            }
            _funcionariosRepository.Inserir(novoFuncionario);

            return Created("http://localhost:5000/api/Funcionarios", novoFuncionario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            funcionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            if (funcionarioBuscado != null)
            {
                return Ok(funcionarioBuscado);
            }

            return NotFound("Nenhum funcionario encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, funcionariosDomain funcionarioAtualizado)
        {
            funcionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);
            if (funcionarioBuscado != null)
            {
                _funcionariosRepository.Atualizar(id, funcionarioAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum estudio encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            funcionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            if (funcionarioBuscado != null)
            {
                _funcionariosRepository.Deletar(id);

                return Ok($"O funcionario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum funcionario encontrado para o identificador informado");
        }
    }
}
