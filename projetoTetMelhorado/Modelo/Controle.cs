using projetoTetMelhorado.DAL;
using System;

namespace projetoTetMelhorado.Modelo
{
    public class Controle
    {
        public bool tem;
        public string mensagem = "";

        public bool acessar(string email, string senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            tem = loginDao.verificarLogin(email, senha);
            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;
            }
            return tem;
        }

        public string cadastrar(string nome, string email, string senha, string confSenha, string telefone)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.cadastrar(nome, email, senha, confSenha, telefone);
            if (loginDao.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }


        // Aqui corrigido para chamar o método correto do DAO
    }
}
