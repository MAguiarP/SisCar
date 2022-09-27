using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja finalizar o SisCar?", "SisCar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            Application.Exit();


        }

        public string usuario;

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Bem-Vindo(a) " + usuario + "!";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text="Data: " + DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = "Hora: " + DateTime.Now.ToShortTimeString();
        }

        private void CalculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void ConsultaDetranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("msedge.exe", "https://www.detran.rj.gov.br/");
        }

        private void ExibirBarraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exibirBarraToolStripMenuItem.Checked)
                toolStrip1.Show();
            else
                toolStrip1.Hide();
        }

        private void CorDeFundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg1 = new DialogResult();

            if(this.BackgroundImage != null)
            {
                dlg1 = MessageBox.Show("Deseja descartar o papel de parede atual?", "Cor de Fundo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }

            if((dlg1 == DialogResult.Yes) || (dlg1 == DialogResult.None))
            {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
            this.BackgroundImage = null;
            };
        }

        private void PapelDeParedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Title = "Selecione Imagem de Fundo";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Arquivos de Imagem | (*.bmp;*.jpg;*.gif) | Todos os arquivos | *.*";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.FileName != "")
                this.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes1 = new FrmClientes();
            frmClientes1.ShowDialog();
        }
    }

}



