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
    public partial class NovoProjeto : Form
    {
        public NovoProjeto()
        {
            InitializeComponent();
        }

        private void txbNovoProjeto_TextChanged(object sender, EventArgs e)
        {

        }
        //fim textbox nvo projeto
        private void txbDescricao_TextChanged(object sender, EventArgs e)
        {

        }
        //fim textbox descrição
        private void txbValor_TextChanged(object sender, EventArgs e)
        {
            string textoAtual = txbValor.Text;

            // Remove tudo que não for número ou vírgula
            string filtrado = new string(textoAtual.Where(c => char.IsDigit(c) || c == ',').ToArray());

            // Se algo foi removido, atualiza o TextBox
            if (textoAtual != filtrado)
            {
                int posicao = txbValor.SelectionStart - 1;
                txbValor.Text = filtrado;
                txbValor.SelectionStart = Math.Max(posicao, 0);
            }
        }
        //fim textbox Valor
        private void btnCriar_Click(object sender, EventArgs e)
        {
            string nome = txbNovoProjeto.Text.Trim();
            string descricao = txbDescricao.Text.Trim();
            string valorTexto = txbValor.Text.Trim();
            string qtdTexto = txbQtdPessoas.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao) || string.IsNullOrEmpty(valorTexto) || string.IsNullOrEmpty(qtdTexto))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(valorTexto, out decimal valor))
            {
                MessageBox.Show("Valor inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(qtdTexto, out int qtdPessoas) || qtdPessoas < 1)
            {
                MessageBox.Show("Quantidade de pessoas inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection con = new DAL.Conexao().conectar())
                {
                    string query = "INSERT INTO projetos (nome_projeto, descricao, valor, data_criacao, email_autor, qtd_pessoas) " +
                                   "VALUES (@nome, @descricao, @valor, @data, @autor, @qtd)";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd.Parameters.AddWithValue("@autor", DAL.SessaoUsuario.EmailLogado);
                    cmd.Parameters.AddWithValue("@qtd", qtdPessoas);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Projeto criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar projeto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //fim botão criar
        private void btnCancelarNP_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //fim botão cancelar
        private void NovoProjeto_Load(object sender, EventArgs e)
        {

        }

        private void txbQtdPessoas_TextChanged(object sender, EventArgs e)
        {
            // Permite apenas números
            string somenteNumeros = new string(txbQtdPessoas.Text.Where(char.IsDigit).ToArray());

            if (txbQtdPessoas.Text != somenteNumeros)
            {
                int pos = txbQtdPessoas.SelectionStart - 1;
                txbQtdPessoas.Text = somenteNumeros;
                txbQtdPessoas.SelectionStart = Math.Max(pos, 0);
            }
        }
        //fim text box quantidade de pessoas
    }
}
