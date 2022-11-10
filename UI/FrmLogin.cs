using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;
using BLL;
using System.Linq.Expressions;

namespace UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario usuario = new Usuario();
                usuario.Login = TxtUsuario.Text;
                usuario.Senha = TxtSenha.Text;

                LoginBLL loginBLL = new LoginBLL();

                if (usuarioBLL.verificarLogin(usuario))
                {
                    Login.User = usuario.Login;
                    FrmPrincipal frmPrincipal = new FrmPrincipal();
                    frmPrincipal.usuario = usuario.Login;
                    frmPrincipal.Show();
                    this.Dispose(false);
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha Incorreto! Tente Novamente!", "Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtUsuario.Text = "";
                    TxtSenha.Text = "";
                    TxtUsuario.Focus();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                FrmPrincipal frmPrincipal1 = new FrmPrincipal();
                frmPrincipal1.usuario = TxtUsuario.Text;
                frmPrincipal1.Show();
                this.Dispose();
            
        }

    }
}
