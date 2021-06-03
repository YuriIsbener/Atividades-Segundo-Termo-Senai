using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<HabilidadeDomain> ListarTodos();

        HabilidadeDomain BuscarPorId(int id);

        void Cadastrar(HabilidadeDomain novaHabilidade);

        void Atualizar(int id, HabilidadeDomain habilidadeAtualizada);

        void Deletar(int id);
    }
}
