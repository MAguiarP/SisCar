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
            
            ClienteBLL clientebll = new ClienteBLL();
            Cliente cliente = new Cliente();

            clientebll.InserirCodigo(cliente);
            TxtCOD_CLIENTE.Text = cliente.Cod_Cliente;
            BtEXCLUIR.Enabled = false;
            TxtCOD_CLIENTE.Enabled = false;

        }

        private void BtFECHAR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtGRAVAR_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteBLL clienteBLL = new ClienteBLL();

            try
            {
                cliente.Cod_Cliente = TxtCOD_CLIENTE.Text;
                cliente.Nome = TxtNOME.Text;
                cliente.Cpf = TxtCPF.Text;
                cliente.Data_nasc = TxtDATA_NASC.Text;
                cliente.Endereco = TxtENDERECO.Text;
                cliente.Bairro = TxtBAIRRO.Text;
                cliente.CEP = TxtCEP.Text;
                cliente.Cidade = TxtCIDADE.Text;
                cliente.Estado = CbESTADO.Text;
                cliente.Fone1 = TxtFONE1.Text;
                cliente.Fone2 = TxtFONE2.Text;


                if (RbMASCULINO.Checked)
                    cliente.Sexo = "M";
                else
                    cliente.Sexo = "F";
                if (CkRESTRICAO.Checked)
                    cliente.Restricao = "S";
                else
                    cliente.Restricao = "N";

                clienteBLL.VerificarCampos(cliente);
                clienteBLL.InserirCliente(cliente);

                MessageBox.Show("O Usúario " + cliente.Nome + " foi cadastrado! ", "Cadastro Efetuado com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                ZeraCampos();
                clienteBLL.InserirCodigo(cliente);
                TxtCOD_CLIENTE.Text = cliente.Cod_Cliente;
       
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
