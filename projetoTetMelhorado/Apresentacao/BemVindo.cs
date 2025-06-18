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
using projetoTetMelhorado.Apresentacao;
using Mysqlx.Crud;
using System.IO;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class BemVindo : Form
    {
        public BemVindo()
        {
            InitializeComponent();
        }

        private void BemVindo_Load(object sender, EventArgs e)
        {
            CarregarProjetos();
            CarregarImagemUsuario();

            // Associa o menu à PictureBox do usuário
            pictureBoxUsuario.ContextMenuStrip = contextMenuUsuario;

            // Garante que clique esquerdo também abra o menu
            pictureBoxUsuario.MouseClick += pictureBoxUsuario_MouseClick;
        }

        private void txbPesquisar_TextChanged(object sender, EventArgs e)
        {
            string termo = txbPesquisar.Text.Trim().ToLower();

            foreach (Control ctrl in flowLayoutPanelProjetos.Controls)
            {
                if (ctrl is Panel panel && panel.Controls.Count > 0)
                {
                    Label lblNome = panel.Controls[0] as Label;
                    if (lblNome != null)
                    {
                        string nomeProjeto = lblNome.Text.ToLower();
                        panel.Visible = nomeProjeto.Contains(termo);
                    }
                }
            }
        }

        private void btnNovoProjeto_Click(object sender, EventArgs e)
        {
            NovoProjeto npj = new NovoProjeto();
            npj.FormClosed += (s, args) => CarregarProjetos(); // recarrega ao fechar
            npj.ShowDialog(); // aguarda fechamento
        }

        // Filtro do ComboBox: Mais recentes ou mais antigos
        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltro.SelectedItem.ToString() == "Mais recentes")
            {
                CarregarProjetos("DESC");
            }
            else if (cbFiltro.SelectedItem.ToString() == "Mais antigos")
            {
                CarregarProjetos("ASC");
            }
        }

        // Método principal para carregar os projetos
        private void CarregarProjetos(string ordem = "DESC")
        {
            flowLayoutPanelProjetos.Controls.Clear();

            try
            {
                using (MySqlConnection con = new Conexao().conectar())
                {
                    string query = $@"
            SELECT p.nome_projeto, p.descricao, p.valor, p.data_criacao, p.qtd_pessoas,
                   u.nome AS nome_autor, u.foto_perfil, u.email AS email_autor, u.telefone
            FROM projetos p
            INNER JOIN logins u ON p.email_autor = u.email
            ORDER BY p.data_criacao {ordem}";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nome = reader["nome_projeto"].ToString();
                        string descricao = reader["descricao"].ToString();
                        decimal valor = Convert.ToDecimal(reader["valor"]);
                        DateTime data = Convert.ToDateTime(reader["data_criacao"]);
                        int qtdPessoas = Convert.ToInt32(reader["qtd_pessoas"]);
                        string nomeAutor = reader["nome_autor"].ToString();
                        byte[] fotoAutor = reader["foto_perfil"] != DBNull.Value ? (byte[])reader["foto_perfil"] : null;
                        string emailAutor = reader["email_autor"].ToString();
                        string telefoneAutor = reader["telefone"].ToString();

                        AdicionarProjetoAoFeed(nome, descricao, valor, data, nomeAutor, fotoAutor, emailAutor, telefoneAutor, qtdPessoas);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar projetos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Cria dinamicamente um painel com os dados do projeto
        private void AdicionarProjetoAoFeed(string nome, string descricao, decimal valor, DateTime data,
    string nomeAutor, byte[] fotoAutor, string emailAutor, string telefoneAutor, int qtdPessoas)
        {
            Panel projetoPanel = new Panel();
            projetoPanel.Width = flowLayoutPanelProjetos.Width - 30;
            projetoPanel.Height = 180; // altura aumentada para caber a nova informação
            projetoPanel.BorderStyle = BorderStyle.FixedSingle;
            projetoPanel.Margin = new Padding(10);

            // Foto do autor
            PictureBox picAutor = new PictureBox();
            picAutor.Size = new Size(50, 50);
            picAutor.Location = new Point(10, 10);
            picAutor.SizeMode = PictureBoxSizeMode.Zoom;

            if (fotoAutor != null)
            {
                using (MemoryStream ms = new MemoryStream(fotoAutor))
                {
                    picAutor.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picAutor.BackColor = Color.Gray;
            }

            // Nome do autor
            Label lblAutor = new Label();
            lblAutor.Text = "Por: " + nomeAutor;
            lblAutor.Location = new Point(70, 25);
            lblAutor.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblAutor.AutoSize = true;

            // Nome do projeto
            Label lblNome = new Label();
            lblNome.Text = nome;
            lblNome.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNome.Location = new Point(10, 70);
            lblNome.AutoSize = true;

            // Descrição
            Label lblDescricao = new Label();
            lblDescricao.Text = descricao;
            lblDescricao.Location = new Point(10, 95);
            lblDescricao.Width = projetoPanel.Width - 20;
            lblDescricao.Height = 40;
            lblDescricao.AutoSize = false;

            // Valor
            Label lblValor = new Label();
            lblValor.Text = "Valor: R$ " + valor.ToString("N2");
            lblValor.Location = new Point(10, 140);
            lblValor.AutoSize = true;

            // Quantidade de pessoas
            Label lblQtdPessoas = new Label();
            lblQtdPessoas.Text = "Equipe: " + qtdPessoas + " pessoa(s)";
            lblQtdPessoas.Location = new Point(120, 140);
            lblQtdPessoas.AutoSize = true;

            // Data
            Label lblData = new Label();
            lblData.Text = "Criado em: " + data.ToString("dd/MM/yyyy HH:mm");
            lblData.Location = new Point(250, 140);
            lblData.AutoSize = true;

            // Botão de contato
            Button btnContato = new Button();
            btnContato.Text = "Contato";
            btnContato.Size = new Size(80, 30);
            btnContato.Location = new Point(projetoPanel.Width - 100, 10);
            btnContato.Click += (s, e) =>
            {
                ContatoPerfil formContato = new ContatoPerfil(nomeAutor, emailAutor, telefoneAutor);
                formContato.ShowDialog();
            };

            // Adiciona tudo ao painel
            projetoPanel.Controls.Add(picAutor);
            projetoPanel.Controls.Add(lblAutor);
            projetoPanel.Controls.Add(lblNome);
            projetoPanel.Controls.Add(lblDescricao);
            projetoPanel.Controls.Add(lblValor);
            projetoPanel.Controls.Add(lblQtdPessoas);
            projetoPanel.Controls.Add(lblData);
            projetoPanel.Controls.Add(btnContato);

            flowLayoutPanelProjetos.Controls.Add(projetoPanel);
        }




        private void btnGerenciarPerfil_Click(object sender, EventArgs e)
        {
            GerenciarPerfil perfil = new GerenciarPerfil();
            perfil.Show();
            this.Close();
        }

        private void BemVindo_Load_1(object sender, EventArgs e)
        {
            CarregarProjetos();
            CarregarImagemUsuario();

            // Associa o menu à PictureBox do usuário
            pictureBoxUsuario.ContextMenuStrip = contextMenuUsuario;

            // Garante que clique esquerdo também abra o menu
            pictureBoxUsuario.MouseClick += pictureBoxUsuario_MouseClick;

        }
        private void CarregarImagemUsuario()
        {
            try
            {
                using (MySqlConnection con = new Conexao().conectar())
                {
                    string query = "SELECT foto_perfil FROM logins WHERE email = @Email"; // CORRIGIDO AQUI
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", SessaoUsuario.EmailLogado);

                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        byte[] imagemBytes = (byte[])resultado;
                        using (MemoryStream ms = new MemoryStream(imagemBytes))
                        {
                            pictureBoxUsuario.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxUsuario.Image = null; // sem imagem
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagem do usuário: " + ex.Message);
            }
        }


        private void btnGerenciarPosts_Click(object sender, EventArgs e)
        {
            GerenciarPosts posts = new GerenciarPosts();
            posts.Show();
            this.Close(); // ou .Hide() se quiser manter aberto
        }
        //fim do botão gerenciar posts

        private void pictureBoxUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuUsuario.Show(pictureBoxUsuario, new Point(e.X, e.Y));
            }
        }

        private void gerenciarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GerenciarPerfil().Show();
            this.Close();
        }

        private void novoProjetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GerenciarPosts().Show();
            this.Close();
        }

        private void sairDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessaoUsuario.EmailLogado = null; // Limpa a sessão do usuário

            Form1 login = new Form1(); // Cria uma nova instância da tela de login
            login.Show();              // Mostra a tela de login

            this.Close();
        }
    }
}
