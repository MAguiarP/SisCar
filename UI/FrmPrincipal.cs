﻿using System;
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
    }

}



