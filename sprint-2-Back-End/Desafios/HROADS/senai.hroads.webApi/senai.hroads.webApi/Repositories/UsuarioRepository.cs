using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=Leticia0304";
        public void Atualizar(int id, UsuarioDomain usuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE Usuario SET email = @email, senha = @senha, idTipoDeUsuario = @idTipo WHERE idUsuario = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idTipo", usuarioAtualizado.TipoUsuario.idTipoDeUsuario);
                    cmd.Parameters.AddWithValue("@email", usuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@senha", usuarioAtualizado.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idUsuario AS 'Id do Usuario', email AS 'Email', NomeTipoUsuario AS 'Tipo de Usuario' FROM Usuario LEFT JOIN TipoDeUsuario ON Usuario.idTipoDeUsuario = TipoDeUsuario.idTipoDeUsuario WHERE idUsuario = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            TipoUsuario = new TipoDeUsuarioDomain
                            {
                                nomeTipoUsuario = rdr[2].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(idTipoDeUsuario, email, senha) VALUES ('" + novoUsuario.TipoUsuario.idTipoDeUsuario + "', '"+novoUsuario.email+"', '"+novoUsuario.senha+"')";
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
                string queryDelete = "DELETE FROM Usuario WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idUsuario AS 'Id do Usuario', email AS 'Email', NomeTipoUsuario AS 'Tipo de Usuario' FROM Usuario LEFT JOIN TipoDeUsuario ON Usuario.idTipoDeUsuario = TipoDeUsuario.idTipoDeUsuario";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            TipoUsuario = new TipoDeUsuarioDomain
                            {
                                nomeTipoUsuario = rdr[2].ToString()
                            }
                        };

                        listaUsuarios.Add(usuario);
                    }
                }
            }

            return listaUsuarios;
        }

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario AS 'Id do Usuario', email AS 'Email', NomeTipoUsuario AS 'Tipo de Usuario' FROM Usuario LEFT JOIN TipoDeUsuario ON Usuario.idTipoDeUsuario = TipoDeUsuario.idTipoDeUsuario";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            TipoUsuario = new TipoDeUsuarioDomain
                            {
                                nomeTipoUsuario = rdr[2].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
