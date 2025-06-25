using MySql.Data.MySqlClient;
using projetoTetMelhorado.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class PostsDoUsuario : Form
    {
        private string emailUsuario;

        public PostsDoUsuario(string email)
        {
            InitializeComponent();
            emailUsuario = email;
        }

        public PostsDoUsuario()
        {
            InitializeComponent();
        }

        private void PostsDoUsuario_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Posts de: " + emailUsuario;
            CarregarPostsDoUsuario();
        }

        private void CarregarPostsDoUsuario()
        {
            try
            {
                flowLayoutPanelPosts.Controls.Clear();

                using (MySqlConnection con = new Conexao().conectar())
                {
                    // Busca a imagem do usuário
                    byte[] fotoPerfil = null;

                    string sqlFoto = "SELECT foto_perfil FROM logins WHERE email = @Email";
                    using (MySqlCommand cmdFoto = new MySqlCommand(sqlFoto, con))
                    {
                        cmdFoto.Parameters.AddWithValue("@Email", emailUsuario);
                        var resultado = cmdFoto.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            fotoPerfil = (byte[])resultado;
                        }
                    }

                    // Busca os projetos
                    string sql = @"SELECT id, nome_projeto, descricao, valor, data_criacao 
                           FROM projetos 
                           WHERE email_autor = @Email";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", emailUsuario);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string nome = reader["nome_projeto"].ToString();
                                string desc = reader["descricao"].ToString();
                                string valor = Convert.ToDecimal(reader["valor"]).ToString("C");
                                string data = Convert.ToDateTime(reader["data_criacao"]).ToString("dd/MM/yyyy");

                                flowLayoutPanelPosts.Controls.Add(CriarCardPost(id, nome, desc, valor, data, fotoPerfil));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar posts: " + ex.Message);
            }
        }


        private Panel CriarCardPost(int id, string nome, string descricao, string valor, string data, byte[] fotoPerfil)
        {
            Panel card = new Panel();
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Size = new Size(300, 220);
            card.Margin = new Padding(10);

            PictureBox pic = new PictureBox();
            pic.Size = new Size(60, 60);
            pic.Location = new Point(10, 10);
            pic.SizeMode = PictureBoxSizeMode.Zoom;

            if (fotoPerfil != null)
            {
                using (MemoryStream ms = new MemoryStream(fotoPerfil))
                {
                    pic.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pic.Image = Properties.Resources.avatar_padrao;
            }

            Label lblNome = new Label();
            lblNome.Text = "Projeto: " + nome;
            lblNome.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNome.Location = new Point(80, 25);
            lblNome.AutoSize = true;

            Label lblDescricao = new Label();
            lblDescricao.Text = "Descrição: " + descricao;
            lblDescricao.Location = new Point(10, 80);
            lblDescricao.Size = new Size(280, 40);
            lblDescricao.AutoEllipsis = true;

            Label lblValor = new Label();
            lblValor.Text = "Valor: " + valor;
            lblValor.Location = new Point(10, 125);
            lblValor.AutoSize = true;

            Label lblData = new Label();
            lblData.Text = "Data: " + data;
            lblData.Location = new Point(10, 150);
            lblData.AutoSize = true;

            // Botão Editar
            Button btnEditar = new Button();
            btnEditar.Text = "Editar";
            btnEditar.Size = new Size(75, 30);
            btnEditar.Location = new Point(150, 175); // ajustei a posição para caber o botão Excluir
            btnEditar.Click += (sender, e) =>
            {
                var editar = new EditarPostAdm(id);
                editar.ShowDialog();
                CarregarPostsDoUsuario();
            };

            // Botão Excluir
            Button btnExcluir = new Button();
            btnExcluir.Text = "Excluir";
            btnExcluir.Size = new Size(75, 30);
            btnExcluir.Location = new Point(230, 175);
            btnExcluir.Click += (sender, e) =>
            {
                var resultado = MessageBox.Show("Tem certeza que deseja excluir este post?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    ExcluirPost(id);
                    CarregarPostsDoUsuario();
                }
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblNome);
            card.Controls.Add(lblDescricao);
            card.Controls.Add(lblValor);
            card.Controls.Add(lblData);
            card.Controls.Add(btnEditar);
            card.Controls.Add(btnExcluir);

            return card;
        }

        private void ExcluirPost(int idPost)
        {
            try
            {
                using (MySqlConnection con = new Conexao().conectar())
                {
                    string sqlExcluir = "DELETE FROM projetos WHERE id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlExcluir, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", idPost);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Post excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o post: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
