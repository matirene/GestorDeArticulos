using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    public partial class frmAltaMarca : Form
    {
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        private void btnAceptarAltaMarca_Click(object sender, EventArgs e)
        {

            Validacion validacion = new Validacion();

            if (validacion.isEmpty(txtNombreMarca.Text))
            {
                MessageBox.Show("El campo Nombre esta incompleto", "Agregar Marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = MessageBox.Show("Confirmas agregar esta Marca?", "Agregar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.No)
                return;

            try
            {
                Marca newMarca = new Marca();

                newMarca.Descripcion = txtNombreMarca.Text;

                MarcaNegocio negocio = new MarcaNegocio();

                negocio.agregar(newMarca);

                MessageBox.Show("Marca agregada", "Agregar Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                this.Close();
            }

        }

        private void btnCancelarAltaMarca_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
