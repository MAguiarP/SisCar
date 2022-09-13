using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            FrmPrincipal frmPrincipal1 = new FrmPrincipal();
            frmPrincipal1.usuario = TxtUsuario.Text;
            frmPrincipal1.Show();
            this.Dispose();
        }
    }
}
