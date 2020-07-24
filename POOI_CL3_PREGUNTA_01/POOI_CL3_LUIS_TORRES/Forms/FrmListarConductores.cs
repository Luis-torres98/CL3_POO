using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POOI_CL3_LUIS_TORRES.ADO;

namespace POOI_CL3_LUIS_TORRES.Forms
{
    public partial class FrmListarConductores : Form
    {
        public FrmListarConductores()
        {
            InitializeComponent();
        }

        private void FrmListarConductores_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = new ADOConductor().ListarConductorDS();
            CargarTipoDocumento();
        }

        void CargarTipoDocumento()
        {
            cboTipoDoc.DataSource = new ADOTipoDocumento().Listar();
            cboTipoDoc.DisplayMember = "Nombre";
            cboTipoDoc.ValueMember = "IdTipoDocumento";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = new ADOConductor().BuscarClientesXTD(cboTipoDoc.SelectedIndex +1);
        }
    }
}
