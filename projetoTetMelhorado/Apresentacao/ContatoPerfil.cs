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
    public partial class ContatoPerfil : Form
    {
        public ContatoPerfil(string nome, string email, string telefone)
        {
            InitializeComponent();

            lblNome.Text = "Nome: " + nome;
            lblEmail.Text = "Email: " + email;
            lblTelefone.Text = "Telefone: " + telefone;
        }


        private void ContatoPerfil_Load(object sender, EventArgs e)
        {

        }
    }
}
