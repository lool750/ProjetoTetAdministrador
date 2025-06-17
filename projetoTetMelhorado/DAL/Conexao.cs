using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace projetoTetMelhorado.DAL
{
    internal class Conexao
    {
        MySqlConnection con = new MySqlConnection();

        public Conexao()
        {
            // Ajuste a connection string conforme sua instalação do MySQL Workbench
            con.ConnectionString = "server=localhost;database=projetoLogin;uid=root;pwd=;";
        }

        public MySqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
