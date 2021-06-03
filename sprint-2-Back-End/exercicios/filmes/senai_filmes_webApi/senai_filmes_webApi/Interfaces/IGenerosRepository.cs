using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    public interface IGenerosRepository
    {
        List<GeneroDomain> ListarTodos();
        GeneroDomain BuscarPorId(int id);
        void Cadastrar(GeneroDomain novoGenero);
        void AtualizarIdCorpo(GeneroDomain genero);
        void AtualizarIdUrl(int id, GeneroDomain genero);
        void Deletar(int id);
    }
}
