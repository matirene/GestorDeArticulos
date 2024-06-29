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
    public partial class frmAltaCategoria : Form
    {
        public frmAltaCategoria()
        {
            InitializeComponent();
        }

        private void btnAceptarAltaCat_Click(object sender, EventArgs e)
        {
            Validacion validacion = new Validacion();

            if (validacion.isEmpty(txtNombreCategoria.Text))
            {
                MessageBox.Show("El campo Nombre esta incompleto", "Agregar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = MessageBox.Show("Confirmas agregar esta Categoria?", "Agregar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.No)
                return;

            try
            {
                Categoria newCategoria = new Categoria();

                newCategoria.Descripcion = txtNombreCategoria.Text;

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                categoriaNegocio.agregar(newCategoria);

                MessageBox.Show("Categoria agregada", "Agregar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnCancelarAltaCat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
