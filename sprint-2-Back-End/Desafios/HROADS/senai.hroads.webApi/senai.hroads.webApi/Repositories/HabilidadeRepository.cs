using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=Leticia0304";
        public void Atualizar(int id, HabilidadeDomain habilidadeAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE Habilidade SET idTipoHabilidade = @IDH, NomeHabilidade=@Nome WHERE idHabilidade = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@IDH", habilidadeAtualizada.TH);
                    cmd.Parameters.AddWithValue("@Nome", habilidadeAtualizada.NomeHabilidade);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public HabilidadeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idHabilidade, NomeHabilidade AS Habilidades , NomeTipo AS 'Tipos de Habilidade'  FROM Habilidade INNER JOIN TipoHabilidade ON Habilidade.idTipoHabilidade = TipoHabilidade.idTipoHabilidade WHERE idHabilidade @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        HabilidadeDomain habilidadeBuscada = new HabilidadeDomain()
                        {
                            idHabilidade = Convert.ToInt32(rdr[0]),
                            NomeHabilidade = rdr[1].ToString(),
                            TH = new TipoHabilidadeDomain()
                            {
                                NomeTipo = rdr[2].ToString(),
                            }
                        };

                        return habilidadeBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(HabilidadeDomain novaHabilidade)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Habilidade (NomeHabilidade, idTipoHabilidade) VALUES ('" + novaHabilidade.NomeHabilidade + "', '"+novaHabilidade.TH.idTipoHabilidade+"')";
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
                string queryDelete = "DELETE FROM Habilidade WHERE idHabilidade = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<HabilidadeDomain> ListarTodos()
        {
            List<HabilidadeDomain> listaHabilidade = new List<HabilidadeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idHabilidade, NomeHabilidade AS Habilidades , NomeTipo AS 'Tipos de Habilidade'  FROM Habilidade INNER JOIN TipoHabilidade ON Habilidade.idTipoHabilidade = TipoHabilidade.idTipoHabilidade;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        HabilidadeDomain habilidade = new HabilidadeDomain()
                        {
                            idHabilidade = Convert.ToInt32(rdr[0]),
                            NomeHabilidade = rdr[1].ToString(),
                            TH = new TipoHabilidadeDomain()
                            {
                                NomeTipo = rdr[2].ToString(),
                            }
                        };

                        listaHabilidade.Add(habilidade);
                    }
                }
            }

            return listaHabilidade;
        }
    }
}
