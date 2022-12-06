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
    public partial class FrmModelos : Form
    {
        public FrmModelos()
        {
            InitializeComponent();

            ModeloBLL modelobll = new ModeloBLL();
            Modelo modelo = new Modelo();

            modelobll.InserirCodigo(modelo);
            txtCOD_MODELO.Text = modelo.Cod_Modelo;
        }

        private void ZeraCampos()
        {
            //Limpa todos os campos

            ModeloBLL modelobll = new ModeloBLL();
            Modelo modelo = new Modelo();

            modelobll.InserirCodigo(modelo);
            txtCOD_MODELO.Text = modelo.Cod_Modelo;

            cbMarca.SelectedIndex = -1;
            txtDS_MODELO.Clear();
            txtDS_MODELO.Focus();
            btEXCLUIR.Enabled = false;
        }

        private void PreencherDataGrid(String NomeCliente)
        {
            ModeloBLL modelobll = new ModeloBLL();
            dataGridView1.DataSource = modelobll.ConsultarModelo(NomeCliente);

            dataGridView1.Columns[0].HeaderText = "Código"; 
            dataGridView1.Columns[1].HeaderText = "Marca";
            dataGridView1.Columns[2].HeaderText = "Modelo";
        }
                
        private void FrmModelos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                ZeraCampos();

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void FrmModelos_Load(object sender, EventArgs e)
        {
            Marca marca = new Marca ();
            MarcaBLL marcabll = new MarcaBLL();

            marcabll.RetornaMarca();

            cbMarca.DataSource = marcabll.retornaMarca(); 
            cbMarca.DisplayMember = marcabll.retornaMarca().Columns[1].ToString();
            cbMarca.ValueMember = marcabll.retornaMarca().Columns[0].ToString();
            cbMarca.SelectedIndex = -1;            
        }

        private void BtGRAVAR_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            ModeloBLL modelobll = new ModeloBLL();            

            try
            {
                int Codigo = Convert.ToInt32(cbMarca.SelectedValue);

                modelo.Cod_Modelo = txtCOD_MODELO.Text;
                modelo.Cod_Marca = Convert.ToString(Codigo);
                modelo.Ds_Modelo = txtDS_MODELO.Text;

                modelobll.VerificarCampos(modelo);

                modelobll.InserirModelo(modelo);
                MessageBox.Show("O modelo " + modelo.Ds_Modelo + " foi cadastrado!", "Cadastro Efetuado com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ZeraCampos();
                modelobll.InserirCodigo(modelo);
                txtCOD_MODELO.Text = modelo.Cod_Modelo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtEXCLUIR_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            ModeloBLL modelobll = new ModeloBLL();

            modelo.Cod_Modelo = txtCOD_MODELO.Text;
            modelo.Ds_Modelo = txtDS_MODELO.Text;

            if (MessageBox.Show("Deseja EXCLUIR o modelo " + modelo.Ds_Modelo + "?", "Excluir Modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                modelobll.ExcluirModelo(modelo);
                ZeraCampos();
                modelobll.InserirCodigo(modelo);
                txtCOD_MODELO.Text = modelo.Cod_Modelo;
                btEXCLUIR.Enabled = false;
            }
        }

        private void TabPage2_Enter(object sender, EventArgs e)
        {
            PreencherDataGrid(null);
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Modelo Modelo = new Modelo();

            try
            {
                tabControl1.SelectTab(0);
                txtDS_MODELO.Focus();
                btEXCLUIR.Enabled = true;
                txtCONSULTA.Text = "";

                txtCOD_MODELO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbMarca.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDS_MODELO.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("A Pesquisa selecionada, não contém Dados!", "Consulta Vazia!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ZeraCampos();
            }
        }

        private void TxtCONSULTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PreencherDataGrid(txtCONSULTA.Text);
        }

        private void BtFECHAR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
