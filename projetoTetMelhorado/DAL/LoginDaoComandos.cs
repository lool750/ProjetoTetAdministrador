using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projetoTetMelhorado.DAL
{
    internal class LoginDaoComandos
    {
        public bool tem = false;
        public string mensagem = "";

        public string AtualizarFotoPerfil(string email, byte[] novaFoto)
        {
            try
            {
                using (MySqlConnection con = new Conexao().conectar())
                {
                    string query = "UPDATE logins SET foto_perfil = @foto WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@foto", novaFoto);
                    cmd.Parameters.AddWithValue("@Email", email);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return "Foto atualizada com sucesso!";
                    }
                    else
                    {
                        return "Nenhum usuário encontrado com esse e-mail.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar foto: " + ex.Message;
            }
        }


        public bool verificarLogin(string email, string senha)
        {
            using (MySqlConnection con = new Conexao().conectar())
            {
                try
                {
                    string query = "SELECT * FROM logins WHERE email = @email AND senha = @senha";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        tem = reader.HasRows;
                    }
                }
                catch (MySqlException ex)
                {
                    mensagem = "Erro com o banco: " + ex.Message;
                }
                return tem;
            }
        }

        public string cadastrar(string nome, string email, string senha, string confSenha, string telefone, string tipo)
        {
            if (senha != confSenha)
            {
                return "Senhas não coincidem!";
            }

            using (MySqlConnection con = new Conexao().conectar())
            {
                try
                {
                    // Verificar se já existe o e-mail
                    string verificarQuery = "SELECT * FROM logins WHERE email = @email";
                    MySqlCommand verificarCmd = new MySqlCommand(verificarQuery, con);
                    verificarCmd.Parameters.AddWithValue("@email", email);
                    using (var reader = verificarCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return "E-mail já cadastrado.";
                        }
                    }

                    // Cadastrar
                    string insertQuery = "INSERT INTO logins (nome, email, senha, telefone, tipo) VALUES (@nome, @email, @senha, @telefone, @tipo)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@nome", nome);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@senha", senha);
                    insertCmd.Parameters.AddWithValue("@telefone", telefone);
                    insertCmd.Parameters.AddWithValue("@tipo", tipo);
                    insertCmd.ExecuteNonQuery();

                    tem = true;
                    return "Cadastro realizado com sucesso!";
                }
                catch (MySqlException ex)
                {
                    return "Erro ao cadastrar: " + ex.Message;
                }
            }
        }


    }
}
