using projetoTetMelhorado.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoTetMelhorado.Apresentacao
{
    public partial class CadastreSe : Form
    {
        private bool CamposPreenchidos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) || // Email
                string.IsNullOrWhiteSpace(textBox2.Text) || // Senha
                string.IsNullOrWhiteSpace(textBox5.Text) || // Confirmar senha
                string.IsNullOrWhiteSpace(txbTelefone.Text)) // Telefone
            {
                return false;
            }

            // Valida e-mail
            if (!EmailValido(textBox1.Text))
            {
                MessageBox.Show("E-mail inválido. Por favor, insira um e-mail válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool EmailValido(string email)
        {
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padraoEmail);
        }
        public CadastreSe()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //fim do email
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //fim do senha
        

        private void CadastreSe_Load(object sender, EventArgs e)
        {

        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        //fim do confirmar senha
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!CamposPreenchidos())
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Controle controle = new Controle();
            string mensagem = controle.cadastrar(textBoxNome.Text, textBox1.Text, textBox2.Text, textBox5.Text, txbTelefone.Text);


            if (controle.tem) // mensagem de sucesso
            {
                MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // opcional: fechar cadastro após sucesso
            }
            else
            {
                MessageBox.Show(controle.mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //fim do botão cadastrar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //fim do botão cancelar
        private void txbTelefone_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição do cursor para ajustar depois
            int pos = txbTelefone.SelectionStart;

            // Remove tudo que não é número
            string somenteNumeros = new string(txbTelefone.Text.Where(char.IsDigit).ToArray());

            // Limita o tamanho a 11 dígitos (DDD + número)
            if (somenteNumeros.Length > 11)
                somenteNumeros = somenteNumeros.Substring(0, 11);

            // Aplica a máscara
            string telefoneFormatado = "";

            if (somenteNumeros.Length <= 2)
                telefoneFormatado = "(" + somenteNumeros;
            else if (somenteNumeros.Length <= 7)
                telefoneFormatado = "(" + somenteNumeros.Substring(0, 2) + ")" + somenteNumeros.Substring(2);
            else
                telefoneFormatado = "(" + somenteNumeros.Substring(0, 2) + ")" +
                                   somenteNumeros.Substring(2, 5) + "-" +
                                   somenteNumeros.Substring(7);

            // Só atualiza se o texto mudou, para evitar loop
            if (txbTelefone.Text != telefoneFormatado)
            {
                txbTelefone.Text = telefoneFormatado;

                // Ajusta o cursor para o final do texto
                txbTelefone.SelectionStart = txbTelefone.Text.Length;
            }
        }
        //fim do textbox telefone

    }
}
