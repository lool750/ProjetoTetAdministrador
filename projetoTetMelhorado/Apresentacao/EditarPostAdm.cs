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
    public partial class EditarPostAdm : Form
    {
        int idPost;

        public EditarPostAdm(int id)
        {
            InitializeComponent();
            idPost = id;
        }

        private void EditarPostAdm_Load(object sender, EventArgs e)
        {
            CarregarDadosDoPost();
        }

        private void CarregarDadosDoPost()
        {
            try
            {
                Conexao conexao = new Conexao();
                string sql = "SELECT nome_projeto, descricao, valor FROM projetos WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.conectar());
                cmd.Parameters.AddWithValue("@id", idPost);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNomeProjeto.Text = reader["nome_projeto"].ToString();
                    txtDescricao.Text = reader["descricao"].ToString();
                    txtValor.Text = reader["valor"].ToString();
                }

                conexao.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao conexao = new Conexao();
                string sql = @"UPDATE projetos 
                               SET nome_projeto = @nome, descricao = @descricao, valor = @valor 
                               WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao.conectar());
                cmd.Parameters.AddWithValue("@nome", txtNomeProjeto.Text.Trim());
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                cmd.Parameters.AddWithValue("@valor", Convert.ToDecimal(txtValor.Text));
                cmd.Parameters.AddWithValue("@id", idPost);

                cmd.ExecuteNonQuery();
                conexao.desconectar();

                MessageBox.Show("Post atualizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }
        //fim do botão salvar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //fim do botão cancelar
    }
}
