using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=Leticia0304";

        public void Atualizar(int id, funcionariosDomain funcionarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE idFuncionario = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioAtualizado.Sobrenome);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public funcionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM funcionarios WHERE idFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        funcionariosDomain funcionarioBuscado = new funcionariosDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()

                        };

                        return funcionarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM funcionarios WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(funcionariosDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO funcionarios(Nome, Sobrenome) VALUES ('" + novoFuncionario.Nome + "','"+ novoFuncionario.Sobrenome+ "')";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<funcionariosDomain> Listar()
        {
            List<funcionariosDomain> listaFuncionarios = new List<funcionariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM funcionarios;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        funcionariosDomain funcionario = new funcionariosDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString()

                        };

                        listaFuncionarios.Add(funcionario);
                    }
                }
            }

            return listaFuncionarios;
        }
    }
}
