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
using Models;
using BLL;


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
            PerfilBLL perfilbll = new PerfilBLL();
            Perfil perfil = new Perfil();
            toolStripStatusLabel1.Text = "Bem-Vindo(a) " + usuario + "!";

            if (perfilbll.VerificarCoreFundo(perfil).Equals("C"))
                this.BackColor = ColorTranslator.FromHtml(perfilbll.RetornarCoreFundo(perfil));
            else if (perfilbll.VerificarCoreFundo(perfil).Equals("I"))
                this.BackgroundImage = Image.FromFile(perfilbll.RetornarCoreFundo(perfil));
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
                Perfil perfil = new Perfil();
                PerfilBLL perfilbll = new PerfilBLL();

                colorDialog1.ShowDialog();
                this.BackColor = colorDialog1.Color;
                perfil.Cor = ColorTranslator.ToHtml(this.BackColor);
                perfilbll.SalvarCor(perfil);
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
            {
                this.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                Perfil perfil = new Perfil();
                PerfilBLL perfilbll = new PerfilBLL();

                perfil.Imagem = openFileDialog1.FileName;
                perfilbll.SalvarImagem(perfil);
            };

        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes1 = new FrmClientes();
            frmClientes1.ShowDialog();
        }

        private void MarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcas1 = new frmMarcas();
            frmMarcas1.ShowDialog();
        }

        private void ModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModelos frmModelos1 = new FrmModelos();
            frmModelos1.ShowDialog();
        }

        private void UsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios1 = new FrmUsuarios();
            frmUsuarios1.ShowDialog();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            frmMovimentacao frmMovimentacao1 = new frmMovimentacao();
            frmMovimentacao1.Entrada_Saida = "E";
            frmMovimentacao1.ShowDialog();


        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            frmMovimentacao frmMovimentacao1 = new frmMovimentacao();
            frmMovimentacao1.Entrada_Saida = "E";
            frmMovimentacao1.ShowDialog();


        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoque frmEstoque1 = new frmEstoque();
            frmEstoque1.ShowDialog();
        }
    }

}



