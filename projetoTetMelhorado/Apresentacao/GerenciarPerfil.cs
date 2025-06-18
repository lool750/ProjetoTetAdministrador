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
using System.IO;
using MySql.Data.MySqlClient;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class GerenciarPerfil : Form
    {
        public GerenciarPerfil()
        {
            InitializeComponent();
        }

        private void GerenciarPerfil_Load(object sender, EventArgs e)
        {
            lblEmail.Text = SessaoUsuario.EmailLogado;
            CarregarFotoPerfil();
            CarregarDadosDoUsuario(); // <- novo método
        }

        private void btnSairDaConta_Click(object sender, EventArgs e)
        {
            SessaoUsuario.EmailLogado = null; // Limpa a sessão do usuário

            Form1 login = new Form1(); // Cria uma nova instância da tela de login
            login.Show();              // Mostra a tela de login

            this.Close();
        }

        private void btnVoltaBV_Click(object sender, EventArgs e)
        {
            BemVindo bemVindo = new BemVindo();
            bemVindo.Show();  // Abre a tela de Bem-Vindo novamente
            this.Close();     // Fecha a tela atual (GerenciarPerfil)
        }

        private void btnMIP_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.jpg;*.png)|*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] novaImagem = File.ReadAllBytes(ofd.FileName);

                LoginDaoComandos dao = new LoginDaoComandos();
                dao.AtualizarFotoPerfil(SessaoUsuario.EmailLogado, novaImagem);

                // Atualiza a imagem no PictureBox
                pictureBoxPerfil.Image = Image.FromFile(ofd.FileName);
            }
        }
        //Fim do botão mudar imagem de perfil
        private void pictureBoxPerfil_Click(object sender, EventArgs e)
        {

        }
        //fim do picturebox
        private void CarregarFotoPerfil()
        {
            Conexao con = new Conexao();
            {
                MySqlCommand cmd = new MySqlCommand("SELECT foto_perfil FROM logins WHERE email = @email", con.conectar());
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                var resultado = cmd.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    byte[] imagemBytes = (byte[])resultado;

                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        pictureBoxPerfil.Image = Image.FromStream(ms);
                    }
                }

                con.desconectar();
            }
        }

        private void CarregarDadosDoUsuario()
        {
            using (MySqlConnection con = new Conexao().conectar())
            {
                string query = "SELECT nome, senha FROM logins WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", SessaoUsuario.EmailLogado);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nome = reader["nome"].ToString();
                        string senha = reader["senha"].ToString();

                        lblNome.Text = nome;
                        lblSenha.Text = new string('*', senha.Length); // Exibe com asteriscos
                    }
                }
            }
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            EditarPerfil editarPerfil = new EditarPerfil();
            editarPerfil.Show();  // Abre a tela EditarPerfil
            this.Close();         // Fecha a tela GerenciarPerfil (opcional: pode usar Hide() se quiser manter aberta)
        }

        //fim botão editar perfil
    }
}
