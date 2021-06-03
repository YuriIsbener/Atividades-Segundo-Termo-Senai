using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoDeUsuarioRepository
    {
        List<TipoDeUsuarioDomain> ListarTodos();

        TipoDeUsuarioDomain BuscarPorId(int id);

        void Cadastrar(TipoDeUsuarioDomain novoTipoUsuario);

        void Atualizar(int id, TipoDeUsuarioDomain tipoUsuarioAtualizado);

        void Deletar(int id);
    }
}
