using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseRepository
    {
        List<ClasseDomain> ListarTodos();

        ClasseDomain BuscarPorId(int id);

        void Cadastrar(ClasseDomain novaClasse);

        void Atualizar(int id, ClasseDomain classeAtualizada);

        void Deletar(int id);
    }
}
