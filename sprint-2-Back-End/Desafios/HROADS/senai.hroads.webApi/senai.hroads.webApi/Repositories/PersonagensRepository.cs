using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class PersonagensRepository : IPersonagensRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=Leticia0304";
        public void Atualizar(int id, PersonagensDomain personagemAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE Personagens SET NomePersonagem = @Nome, idClasse = @classe, CapacidadeVida = @Vida, CapacidadeMana = @Mana, DataAtualizacao = @data WHERE idPersonagem = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", personagemAtualizado.NomePersonagem);
                    cmd.Parameters.AddWithValue("@classe", personagemAtualizado.Classe.IdClasse);
                    cmd.Parameters.AddWithValue("@Vida", personagemAtualizado.CapacidadeVida);
                    cmd.Parameters.AddWithValue("@Mana", personagemAtualizado.CapacidadeMana);
                    DateTime DataAtualizada = DateTime.Now;
                    cmd.Parameters.AddWithValue("@data", DataAtualizada);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public PersonagensDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idPersonagem, NomePersonagem AS Personagem, NomeClasse AS Classe, CapacidadeVida, CapacidadeMana, DataCriacao FROM Personagens INNER JOIN Classe ON Personagens.idClasse = Classe.idClasse WHERE idPersonagem @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        PersonagensDomain personagenBuscado = new PersonagensDomain()
                        {
                            idPersonagem = Convert.ToInt32(rdr[0]),
                            NomePersonagem = rdr[1].ToString(),
                            Classe = new ClasseDomain() 
                            { 
                                NomeClasse = rdr[2].ToString()
                            },
                            CapacidadeVida = Convert.ToInt32(rdr[3]),
                            CapacidadeMana = Convert.ToInt32(rdr[4]),
                            DataCriacao = Convert.ToDateTime(rdr[5])
                        };

                        return personagenBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(PersonagensDomain novoPersonagem)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Personagens(NomePersonagem, idClasse, CapacidadeVida, CapacidadeMana, DataAtualizacao, DataCriacao) VALUES ('" + novoPersonagem.NomePersonagem + "', '"+novoPersonagem.Classe.IdClasse+"', '"+novoPersonagem.CapacidadeVida+"', '"+novoPersonagem.CapacidadeMana+"', @dataA, @dataC)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    DateTime DataA = DateTime.Now;
                    DateTime DataC = DateTime.Now;

                    cmd.Parameters.AddWithValue("@dataA", DataA);
                    cmd.Parameters.AddWithValue("@dataC", DataC);


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Personagens WHERE idPersonagem = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PersonagensDomain> ListarTodos()
        {
            List<PersonagensDomain> listaPersonagens = new List<PersonagensDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idPersonagem, NomePersonagem AS Personagem, NomeClasse AS Classe, CapacidadeVida, CapacidadeMana, DataCriacao FROM Personagens INNER JOIN Classe ON Personagens.idClasse = Classe.idClasse";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PersonagensDomain personagem = new PersonagensDomain()
                        {
                            idPersonagem = Convert.ToInt32(rdr[0]),
                            NomePersonagem = rdr[1].ToString(),
                            Classe = new ClasseDomain()
                            {
                                NomeClasse = rdr[2].ToString()
                            },
                            CapacidadeVida = Convert.ToInt32(rdr[3]),
                            CapacidadeMana = Convert.ToInt32(rdr[4]),
                            DataCriacao = Convert.ToDateTime(rdr[5])
                        };

                        listaPersonagens.Add(personagem);
                    }
                }
            }

            return listaPersonagens;
        }
    }
}
