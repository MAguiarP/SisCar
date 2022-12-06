using BLL;
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
    public partial class FrmGraficos : Form
    {
        public FrmGraficos()
        {
            InitializeComponent();
        }

        private void BtFECHAR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GraficoBLL graficobll = GraficoBLL();
            chart1.DataSource = graficobll.ConsultarMarca();
            chart1.Series["Series1"].XValueMember = "X";
            chart1.Series["Series1"].YValueMembers= "Y";
            chart1.DataBind();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GraficoBLL graficobll = GraficoBLL();
            chart1.DataSource = graficobll.ConsultarModelo();
            chart1.Series["Series1"].XValueMember = "X";
            chart1.Series["Series1"].YValueMembers = "Y";
            chart1.DataBind();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Series1"].IsVisibleInLegend = false;

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.Series["Series1"].IsVisibleInLegend = true;
        }

        private void FrmGraficos_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
