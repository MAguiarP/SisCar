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

namespace UI
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void BtFECHAR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtGRAVAR_Click(object sender, EventArgs e)
        {

        }

        private void FrmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { }
            ZeraCampos();

            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void ZeraCampos()
        {
            //Limpa todos os campos
            TxtNOME.Clear();
            TxtCPF.Clear();
            TxtDATA_NASC.Clear();
            TxtENDERECO.Clear();
            TxtBAIRRO.Clear();
            TxtCEP.Clear();
            TxtCIDADE.Clear();
            TxtFONE1.Clear();
            TxtFONE2.Clear();
            CbESTADO.SelectedIndex = -1;
            RbMASCULINO.Checked = false;
            RbFEMININO.Checked = false;
            CkRESTRICAO.Checked = false;
            TxtCOD_CLIENTE.Enabled = false;
            TxtCOD_CLIENTE.Enabled = false;
            TxtNOME.Focus();


        }

    }
}
