using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);

        List<UsuarioDomain> ListarTodos();

        UsuarioDomain BuscarPorId(int id);

        void Cadastrar(UsuarioDomain novoUsuario);

        void Atualizar(int id, UsuarioDomain usuarioAtualizado);

        void Deletar(int id);
    }
}
