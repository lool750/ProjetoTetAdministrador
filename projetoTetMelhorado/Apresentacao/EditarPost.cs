using MySql.Data.MySqlClient;
using projetoTetMelhorado.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class EditarPost : Form
    {
        private int projetoId;

        public EditarPost(int id, string nome, string descricao, decimal valor) : this()
        {
            projetoId = id;
            txtNome.Text = nome;
            txtDescricao.Text = descricao;
            txtValor.Text = valor.ToString("N2");
        }

        public EditarPost()
        {
            InitializeComponent();
        }

        private void EditarPost_Load(object sender, EventArgs e)
        {
            // Você pode carregar algo adicional aqui se necessário.
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string novoNome = txtNome.Text.Trim();
                string novaDescricao = txtDescricao.Text.Trim();
                decimal novoValor = decimal.Parse(txtValor.Text);

                using (MySqlConnection con = new Conexao().conectar())
                {
                    string updateQuery = @"UPDATE projetos 
                                           SET nome_projeto = @Nome, descricao = @Descricao, valor = @Valor 
                                           WHERE id = @Id";

                    MySqlCommand cmd = new MySqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@Nome", novoNome);
                    cmd.Parameters.AddWithValue("@Descricao", novaDescricao);
                    cmd.Parameters.AddWithValue("@Valor", novoValor);
                    cmd.Parameters.AddWithValue("@Id", projetoId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Projeto atualizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar projeto: " + ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            BemVindo bemVindo = new BemVindo();
            bemVindo.Show();  // Abre a tela de Bem-Vindo novamente
            this.Close();     // Fecha a tela atual (GerenciarPerfil)
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            var txtBox = sender as TextBox;
            if (txtBox == null) return;

            string texto = txtBox.Text;

            // Filtra só dígitos e vírgula
            string filtrado = new string(texto.Where(c => char.IsDigit(c) || c == ',').ToArray());

            if (texto != filtrado)
            {
                int pos = txtBox.SelectionStart - 1;
                txtBox.Text = filtrado;
                // Ajusta a posição do cursor para evitar salto
                txtBox.SelectionStart = Math.Max(pos, 0);
            }
        }
    }
}
