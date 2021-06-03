using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=Leticia0304";
        public void Atualizar(int id, TipoDeUsuarioDomain tipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE TipoDeUsuario SET NomeTipoUsuario = @NovoNomeTipo WHERE idTipoDeUsuario = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NovoNomeTipo", tipoUsuarioAtualizado.nomeTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoDeUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM TipoDeUsuario WHERE idTipoDeUsuario = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        TipoDeUsuarioDomain tipoDeUsuarioBuscado = new TipoDeUsuarioDomain()
                        {
                            idTipoDeUsuario = Convert.ToInt32(rdr[0]),
                            nomeTipoUsuario = rdr[1].ToString()
                        };

                        return tipoDeUsuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(TipoDeUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoDeUsuario(NomeTipoUsuario) VALUES ('" + novoTipoUsuario.nomeTipoUsuario + "')";
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
                string queryDelete = "DELETE FROM TipoDeUsuario WHERE idTipoDeUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoDeUsuarioDomain> ListarTodos()
        {
            List<TipoDeUsuarioDomain> listaTipoUsuario = new List<TipoDeUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM TipoDeUsuario;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TipoDeUsuarioDomain tipoUsuario = new TipoDeUsuarioDomain()
                        {
                            idTipoDeUsuario = Convert.ToInt32(rdr[0]),
                            nomeTipoUsuario = rdr[1].ToString()
                        };

                        listaTipoUsuario.Add(tipoUsuario);
                    }
                }
            }

            return listaTipoUsuario;
        }
    }
}
