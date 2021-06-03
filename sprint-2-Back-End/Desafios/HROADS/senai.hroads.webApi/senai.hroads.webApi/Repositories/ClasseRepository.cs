using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=Leticia0304";
        public void Atualizar(int id, ClasseDomain classeAtualizada)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE Classe SET NomeClasse = @Nome WHERE idClasse = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", classeAtualizada.NomeClasse);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClasseDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idClasse, NomeClasse FROM Classe WHERE idClasse = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ClasseDomain classeBuscada = new ClasseDomain()
                        {
                            IdClasse = Convert.ToInt32(rdr[0]),
                            NomeClasse = rdr[1].ToString()
                        };

                        return classeBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClasseDomain novaClasse)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Classe(NomeClasse) VALUES ('" + novaClasse.NomeClasse + "')";
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
                string queryDelete = "DELETE FROM Classe WHERE idClasse = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClasseDomain> ListarTodos()
        {
            List<ClasseDomain> listaClasse = new List<ClasseDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Classe;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ClasseDomain classe = new ClasseDomain()
                        {
                            IdClasse = Convert.ToInt32(rdr[0]),
                            NomeClasse = rdr[1].ToString()
                        };

                        listaClasse.Add(classe);
                    }
                }
            }

            return listaClasse;
        }
    }
}
