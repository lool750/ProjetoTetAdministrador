using MySql.Data.MySqlClient;
using projetoTetMelhorado.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class EditarPerfil : Form
    {
        public EditarPerfil()
        {
            InitializeComponent();
        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = new Conexao().conectar())
            {
                string query = "SELECT nome, telefone FROM logins WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNomeAtual.Text = reader["nome"].ToString();
                        txtNovoTelefone.Text = reader["telefone"].ToString();
                    }
                }
            }
        }

        private void btnSalvarNome_Click(object sender, EventArgs e)
        {
            string novoNome = txtNovoNome.Text.Trim();

            if (string.IsNullOrEmpty(novoNome))
            {
                MessageBox.Show("Informe um novo nome.");
                return;
            }

            using (MySqlConnection con = new Conexao().conectar())
            {
                string query = "UPDATE logins SET nome = @nome WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nome", novoNome);
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Nome atualizado com sucesso!");
                lblNomeAtual.Text = novoNome;
                txtNovoNome.Clear();
            }
        }
        //fim do botao salvar nome

        private void btnSalvarSenha_Click(object sender, EventArgs e)
        {
            string novaSenha = txtNovaSenha.Text.Trim();
            string confirmarSenha = txtConfirmarSenha.Text.Trim();

            if (string.IsNullOrEmpty(novaSenha))
            {
                MessageBox.Show("Digite a nova senha.");
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            using (MySqlConnection con = new Conexao().conectar())
            {
                string query = "UPDATE logins SET senha = @senha WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@senha", novaSenha);
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Senha atualizada com sucesso!");
                txtNovaSenha.Clear();
                txtConfirmarSenha.Clear();
            }
        }
        //fim do botao salvar senha
        private void btnSalvarTelefone_Click(object sender, EventArgs e)
        {
            string telefoneFormatado = txtNovoTelefone.Text.Trim();
            string telefoneNumerico = new string(telefoneFormatado.Where(char.IsDigit).ToArray());

            if (telefoneNumerico.Length != 11)
            {
                MessageBox.Show("O telefone deve conter exatamente 11 números (incluindo o DDD).");
                return;
            }

            using (MySqlConnection con = new Conexao().conectar())
            {
                string query = "UPDATE logins SET telefone = @telefone WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@telefone", telefoneNumerico);
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Telefone atualizado com sucesso!");
            }
        }
        //fim do botao salvar telefone
        private void btnSalvarTudo_Click(object sender, EventArgs e)
        {
            string novoNome = txtNovoNome.Text.Trim();
            string novaSenha = txtNovaSenha.Text.Trim();
            string confirmarSenha = txtConfirmarSenha.Text.Trim();
            string novoTelefone = txtNovoTelefone.Text.Trim();

            // Remove máscara para validar o telefone
            string telefoneNumeros = new string(novoTelefone.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(novoNome) && string.IsNullOrEmpty(novaSenha) && string.IsNullOrEmpty(telefoneNumeros))
            {
                MessageBox.Show("Nenhuma alteração informada.");
                return;
            }

            if (!string.IsNullOrEmpty(novaSenha) && novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            if (!string.IsNullOrEmpty(novoTelefone) && telefoneNumeros.Length != 11)
            {
                MessageBox.Show("Telefone deve conter 11 dígitos numéricos.");
                return;
            }

            using (MySqlConnection con = new Conexao().conectar())
            {
                List<string> campos = new List<string>();
                if (!string.IsNullOrEmpty(novoNome)) campos.Add("nome = @nome");
                if (!string.IsNullOrEmpty(novaSenha)) campos.Add("senha = @senha");
                if (!string.IsNullOrEmpty(telefoneNumeros)) campos.Add("telefone = @telefone");

                string query = "UPDATE logins SET " + string.Join(", ", campos) + " WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, con);

                if (!string.IsNullOrEmpty(novoNome)) cmd.Parameters.AddWithValue("@nome", novoNome);
                if (!string.IsNullOrEmpty(novaSenha)) cmd.Parameters.AddWithValue("@senha", novaSenha);
                if (!string.IsNullOrEmpty(telefoneNumeros)) cmd.Parameters.AddWithValue("@telefone", telefoneNumeros);
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                int linhas = cmd.ExecuteNonQuery();

                if (linhas > 0)
                {
                    MessageBox.Show("Dados atualizados com sucesso!");

                    if (!string.IsNullOrEmpty(novoNome))
                    {
                        lblNomeAtual.Text = novoNome;
                        txtNovoNome.Clear();
                    }

                    if (!string.IsNullOrEmpty(novaSenha))
                    {
                        txtNovaSenha.Clear();
                        txtConfirmarSenha.Clear();
                    }

                    if (!string.IsNullOrEmpty(novoTelefone))
                    {
                        txtNovoTelefone.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }
        }
        //fim do botao salvar tudo
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GerenciarPerfil gerenciarPerfil = new GerenciarPerfil();
            gerenciarPerfil.Show();  // Abre a tela GerenciarPerfil
            this.Close();            // Fecha a tela atual (EditarPerfil)
        }
        //fim do botao cancelar/voltar
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNovoTelefone_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição atual do cursor
            int pos = txtNovoTelefone.SelectionStart;

            // Remove tudo que não é número
            string somenteNumeros = new string(txtNovoTelefone.Text.Where(char.IsDigit).ToArray());

            // Limita a 11 dígitos (por exemplo: (99)99999-9999)
            if (somenteNumeros.Length > 11)
                somenteNumeros = somenteNumeros.Substring(0, 11);

            // Aplica a máscara de telefone
            string telefoneFormatado = "";

            if (somenteNumeros.Length <= 2)
                telefoneFormatado = "(" + somenteNumeros;
            else if (somenteNumeros.Length <= 7)
                telefoneFormatado = "(" + somenteNumeros.Substring(0, 2) + ")" + somenteNumeros.Substring(2);
            else
                telefoneFormatado = "(" + somenteNumeros.Substring(0, 2) + ")" +
                                    somenteNumeros.Substring(2, 5) + "-" +
                                    somenteNumeros.Substring(7);

            // Só atualiza se o texto mudou
            if (txtNovoTelefone.Text != telefoneFormatado)
            {
                txtNovoTelefone.Text = telefoneFormatado;

                // Reposiciona o cursor corretamente
                txtNovoTelefone.SelectionStart = txtNovoTelefone.Text.Length;
            }
        }
        //fim do TextBox Novo Telefone
    }
}
