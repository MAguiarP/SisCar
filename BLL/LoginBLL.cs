using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class LoginBLL
    {
        public bool VerificarLogin(Usuario usuario)
        {
          if(usuario.Login.Trim().Length == 0)
            {
                throw new Exception("Por Favor, Informe o seu usuário!");
            }

          if(usuario.Senha.Trim().Length == 0)
            {
                throw new Exception("Por Favor, Informe a sua senha!");
            }

            usuario.Login = usuario.Login.ToUpper();

            LoginDAL usuarioDal = new LoginDAL();
            return usuarioDal.VerificarLogin(usuario);
        }
    }
}
