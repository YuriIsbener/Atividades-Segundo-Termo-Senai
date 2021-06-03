using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=Leticia0304";
        public void Atualizar(int id, TipoHabilidadeDomain tipoHabilidadeAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE TipoHabilidade SET NomeTipo = @Nome WHERE idTipoHabilidade = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", tipoHabilidadeAtualizado.NomeTipo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoHabilidadeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM TipoHabilidade WHERE idTipoHabilidade = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        TipoHabilidadeDomain tipoHabilidadeBuscada = new TipoHabilidadeDomain()
                        {
                            idTipoHabilidade = Convert.ToInt32(rdr[0]),
                            NomeTipo = rdr[1].ToString()
                        };

                        return tipoHabilidadeBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(TipoHabilidadeDomain novoTipoHabilidade)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoHabilidade(NomeTipo) VALUES ('" + novoTipoHabilidade.NomeTipo + "')";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TipoHabilidade WHERE idTipoHabilidade = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoHabilidadeDomain> ListarTodos()
        {
            List<TipoHabilidadeDomain> listaTipoHabilidade = new List<TipoHabilidadeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM TipoHabilidade;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TipoHabilidadeDomain classe = new TipoHabilidadeDomain()
                        {
                            idTipoHabilidade = Convert.ToInt32(rdr[0]),
                            NomeTipo = rdr[1].ToString()
                        };

                        listaTipoHabilidade.Add(classe);
                    }
                }
            }

            return listaTipoHabilidade;
        }
    }
}
