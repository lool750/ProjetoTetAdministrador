using projetoTetMelhorado.Apresentacao;
using projetoTetMelhorado.Modelo;
using projetoTetMelhorado.DAL; // <-- necessário para acessar SessaoUsuario
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoTetMelhorado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
        }
        //FIM BOTÃO CADASTRE-SE

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //FIM BOTÃO SAIR

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            button2.Enabled = false;
            try
            {
                Controle controle = new Controle();
                controle.acessar(textBox3.Text, textBox4.Text);

                if (string.IsNullOrEmpty(controle.mensagem))
                {
                    if (controle.tem)
                    {
                        MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Armazena o e-mail na sessão
                        SessaoUsuario.EmailLogado = textBox3.Text;

                        BemVindo bemVindo = new BemVindo();
                        bemVindo.Show();
                        this.Hide(); // opcional, para esconder a tela de login
                    }
                    else
                    {
                        MessageBox.Show("Login não encontrado, verifique login e senha", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Clear();
                        textBox4.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(controle.mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                button2.Enabled = true;
            }
        }
        //FIM BOTÃO ENTRAR

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //FIM txb login

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //FIM txb senha

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
