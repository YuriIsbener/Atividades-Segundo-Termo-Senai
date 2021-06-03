using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionariosRepository
    {
        List<funcionariosDomain> Listar();
        funcionariosDomain BuscarPorId(int id);
        void Inserir(funcionariosDomain novoFuncionario);
        void Atualizar(int id, funcionariosDomain funcionarioAtualizado);
        void Deletar(int id);

    }
}
