using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using POOI_CL3_LUIS_TORRES.Entidades;
using POOI_CL3_LUIS_TORRES.ADO;


namespace POOI_CL3_LUIS_TORRES.Forms
{
    public partial class FrmAgregarConductor : Form
    {
        public FrmAgregarConductor()
        {
            InitializeComponent();
        }

        private void FrmAgregarConductor_Load(object sender, EventArgs e)
        {
            CargarTipoDocumento();
            CargarConductor();
        }

        void CargarTipoDocumento()
        {
            cboTipoDocumento.DataSource = new ADOTipoDocumento().Listar();
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.ValueMember = "IdTipoDocumento";
        }

        void CargarConductor() 
        {
            dtvListarConductor.DataSource = null;
            dtvListarConductor.DataSource = new ADOConductor().Listar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conductor obj = new Conductor()
            {
                Dni = txtDni.Text,
                Nombre = txtNombre.Text,
                ApellidoPaterno = txtApePaterno.Text,
                ApellidoMaterno = txtApeMaterno.Text,
                Brevete = txtBrevete.Text,
                Telefono = txtTlf.Text,
                Estado = txtEstado.Text,
                IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue)
            };

            try
            {
                int resultado = new ADOConductor().Insertar(obj);
                if (resultado == 1)
                {
                    CargarConductor();
                    MessageBox.Show("Se inserto correctamente", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se inserto el conductor", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conductor obj = new Conductor()
            {
                Dni = txtDni.Text,
                Nombre = txtNombre.Text,
                ApellidoPaterno = txtApePaterno.Text,
                ApellidoMaterno = txtApeMaterno.Text,
                Brevete = txtBrevete.Text,
                Telefono = txtTlf.Text,
                Estado = txtEstado.Text,
                IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                ConductorId = Convert.ToInt32(txtIdConductor.Text)
            };

            try
            {
                int resultado = new ADOConductor().Actualizar(obj);
                if (resultado == 1)
                {
                    CargarConductor();
                    MessageBox.Show("Se actualizo correctamente", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se actualizo el conductor", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }


