using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidadeDomain> ListarTodos();

        TipoHabilidadeDomain BuscarPorId(int id);

        void Cadastrar(TipoHabilidadeDomain novoTipoHabilidade);

        void Atualizar(int id, TipoHabilidadeDomain tipoHabilidadeAtualizado);

        void Deletar(int id);
    }
}
