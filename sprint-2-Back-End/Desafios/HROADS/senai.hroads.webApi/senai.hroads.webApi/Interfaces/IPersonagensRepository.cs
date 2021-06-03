using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagensRepository
    {
        List<PersonagensDomain> ListarTodos();

        PersonagensDomain BuscarPorId(int id);

        void Cadastrar(PersonagensDomain novoPersonagem);

        void Atualizar(int id, PersonagensDomain personagemAtualizado);

        void Deletar(int id);
    }
}
