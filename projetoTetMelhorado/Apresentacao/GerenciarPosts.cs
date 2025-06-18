using MySql.Data.MySqlClient;
using projetoTetMelhorado.DAL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class GerenciarPosts : Form
    {
        public GerenciarPosts()
        {
            InitializeComponent();
        }

        private void GerenciarPosts_Load(object sender, EventArgs e)
        {
            CarregarMeusPosts();
        }

        private void CarregarMeusPosts()
        {
            flowLayoutPanelPosts.Controls.Clear();

            try
            {
                using (MySqlConnection con = new Conexao().conectar())
                {
                    // Incluindo qtd_pessoas na query
                    string query = "SELECT id, nome_projeto, descricao, valor, data_criacao, qtd_pessoas FROM projetos WHERE email_autor = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", SessaoUsuario.EmailLogado);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string nome = reader["nome_projeto"].ToString();
                        string descricao = reader["descricao"].ToString();
                        decimal valor = Convert.ToDecimal(reader["valor"]);
                        DateTime data = Convert.ToDateTime(reader["data_criacao"]);
                        int qtdPessoas = Convert.ToInt32(reader["qtd_pessoas"]);

                        AdicionarPostAoPainel(id, nome, descricao, valor, data, qtdPessoas);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar seus posts: " + ex.Message);
            }
        }

        // Atualizei assinatura para receber qtdPessoas
        private void AdicionarPostAoPainel(int id, string nome, string descricao, decimal valor, DateTime data, int qtdPessoas)
        {
            Panel panel = new Panel
            {
                Width = flowLayoutPanelPosts.Width - 30,
                Height = 150,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label lblNome = new Label { Text = nome, Location = new Point(10, 10), Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true };
            Label lblDescricao = new Label { Text = descricao, Location = new Point(10, 35), Width = panel.Width - 20, Height = 40 };
            Label lblValor = new Label { Text = "Valor: R$ " + valor.ToString("N2"), Location = new Point(10, 80), AutoSize = true };
            Label lblData = new Label { Text = "Criado em: " + data.ToString("dd/MM/yyyy HH:mm"), Location = new Point(200, 80), AutoSize = true };

            // Novo label para qtd pessoas
            Label lblQtdPessoas = new Label
            {
                Text = "Equipe: " + qtdPessoas.ToString() + " pessoa(s)",
                Location = new Point(10, 110),
                AutoSize = true
            };

            Button btnEditar = new Button
            {
                Text = "Editar",
                Location = new Point(panel.Width - 190, 100),
                Size = new Size(80, 30)
            };
            // Passando qtdPessoas no clique do botão editar
            btnEditar.Click += (s, e) => EditarPost(id, nome, descricao, valor, qtdPessoas);

            Button btnExcluir = new Button
            {
                Text = "Excluir",
                Location = new Point(panel.Width - 100, 100),
                Size = new Size(80, 30)
            };
            btnExcluir.Click += (s, e) => ExcluirPost(id);

            panel.Controls.Add(lblNome);
            panel.Controls.Add(lblDescricao);
            panel.Controls.Add(lblValor);
            panel.Controls.Add(lblData);
            panel.Controls.Add(lblQtdPessoas);
            panel.Controls.Add(btnEditar);
            panel.Controls.Add(btnExcluir);

            flowLayoutPanelPosts.Controls.Add(panel);
        }

        // Alterei assinatura para receber qtdPessoas e passar ao form
        private void EditarPost(int id, string nome, string descricao, decimal valor, int qtdPessoas)
        {
            EditarPost formEditar = new EditarPost(id, nome, descricao, valor, qtdPessoas);
            formEditar.FormClosed += (s, e) => CarregarMeusPosts();
            formEditar.ShowDialog();
        }

        private void ExcluirPost(int id)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este projeto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection con = new Conexao().conectar())
                    {
                        string deleteQuery = "DELETE FROM projetos WHERE id = @Id";
                        MySqlCommand cmd = new MySqlCommand(deleteQuery, con);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Projeto excluído com sucesso!");
                    CarregarMeusPosts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir projeto: " + ex.Message);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            BemVindo bemVindo = new BemVindo();
            bemVindo.Show();  // Abre a tela de Bem-Vindo novamente
            this.Close();     // Fecha a tela atual (GerenciarPerfil)
        }
    }
}
