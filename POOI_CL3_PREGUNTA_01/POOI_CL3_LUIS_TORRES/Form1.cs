using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POOI_CL3_LUIS_TORRES.Forms;

namespace POOI_CL3_LUIS_TORRES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listaDeConductoresDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarConductores frm = new FrmListarConductores();
            frm.Show();
        }

        private void agregarConductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarConductor frm = new FrmAgregarConductor();
            frm.Show();
        }
    }
}
