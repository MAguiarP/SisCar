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
        private String consulta = null;

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

        public void BtGRAVAR_Click(object sender, EventArgs e)
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
               
                if (consulta == null)
                {
                    clienteBLL.InserirCliente(cliente);
                    MessageBox.Show("O usuário" + cliente.Nome + "foi cadastrado!", "Cadastro Efetuado com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ZeraCampos();
                    clienteBLL.InserirCliente(cliente);
                    TxtCOD_CLIENTE.Text = cliente.Cod_Cliente;
                }
                else
                {
                    clienteBLL.AtualizarCliente(cliente);
                    MessageBox.Show("A atualização do usuário: " + cliente.Nome + " foi feita com Sucesso!", "Atualização Efetuada com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ZeraCampos();
                    clienteBLL.InserirCodigo(cliente);
                    TxtCOD_CLIENTE.Text = cliente.Cod_Cliente;
                    consulta = null;
                }
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
            ClienteBLL clientebll = new ClienteBLL();
            Cliente cliente = new Cliente();

            clientebll.InserirCodigo(cliente);
            TxtCOD_CLIENTE.Text= cliente.Cod_Cliente;

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
            BtEXCLUIR.Enabled= false;
            consulta = null;


        }

        private void PreencherDataGrid(String NomeCliente)
        {
            ClienteBLL clientebll = new ClienteBLL();
            dataGridView1.DataSource = clientebll.ConsultarCliente(NomeCliente);

            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "CPF";
            dataGridView1.Columns[3].HeaderText = "Data Nasc.";
            dataGridView1.Columns[4].HeaderText = "Endereço";
            dataGridView1.Columns[5].HeaderText = "Bairro";
            dataGridView1.Columns[6].HeaderText = "CEP";
            dataGridView1.Columns[7].HeaderText = "Cidade";
            dataGridView1.Columns[8].HeaderText = "Estado";
            dataGridView1.Columns[9].HeaderText = "Fone 1";
            dataGridView1.Columns[10].HeaderText = "Fone 2";
            dataGridView1.Columns[11].HeaderText = "Sexo";
            dataGridView1.Columns[12].HeaderText = "Restrição";
        }

        private void TabPage2_Enter(object sender, EventArgs e)
        {
            PreencherDataGrid(null);
        }

        private void TxtCONSULTA_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                PreencherDataGrid(TxtCONSULTA.Text);
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ClienteBLL clientebll = new ClienteBLL();
            Cliente cliente = new Cliente();
            try
            {
                tabControl1.SelectTab(0);
                consulta = "S";
                TxtNOME.Focus();
                BtEXCLUIR.Enabled = true;
                TxtCONSULTA.Text = "";

                TxtCOD_CLIENTE.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TxtNOME.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TxtCPF.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                TxtDATA_NASC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                TxtENDERECO.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                TxtBAIRRO.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                TxtCEP.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                TxtCIDADE.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                CbESTADO.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                TxtFONE1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                TxtFONE2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                cliente.Sexo = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                cliente.Restricao = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                if (cliente.Sexo == "M")
                    RbMASCULINO.Checked = true;

                else
                    RbFEMININO.Checked = true;

                if(cliente.Restricao == "S")
                    CkRESTRICAO.Checked = true;
                
                else
                    CkRESTRICAO.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("A Pesquisa selecionada, não contém Dados!", "Consulta Vazia!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BtEXCLUIR_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteBLL clientebll = new ClienteBLL();
            
            cliente.Cod_Cliente = TxtCOD_CLIENTE.Text;
            cliente.Nome = TxtNOME.Text;

        if(MessageBox.Show ( "Deseja EXCLUIR o usuário " + cliente.Nome + "?", "Excluir Cadastro", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clientebll.ExcluirCliente(cliente);
                ZeraCampos();
                clientebll.InserirCodigo(cliente);
                TxtCOD_CLIENTE.Text = cliente.Cod_Cliente;
                consulta = null;
                BtEXCLUIR.Enabled = false;
            }
        }
        
    }
}

