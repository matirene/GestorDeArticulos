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
using dominio;

namespace TPFinal
{
    public partial class frmMarcas : Form
    {

        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmAltaMarca frmAltaMarca = new frmAltaMarca();
            frmAltaMarca.ShowDialog();

            cargarMarcas();

        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (dgvListadoMarcas.CurrentRow != null)
            {

                DialogResult respuesta = MessageBox.Show("Confirmas eliminar esta Marca?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;
                
                Marca seleccionada = (Marca)dgvListadoMarcas.CurrentRow.DataBoundItem;


                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = articuloNegocio.listar();

                foreach (Articulo a in listaArticulos)
                {
                    if (a.Marca.Descripcion.ToUpper() == seleccionada.Descripcion.ToUpper())
                    {
                        MessageBox.Show("No se puede eliminar. Hay articulos registrados con la Marca " + seleccionada.Descripcion + ".", "Eliminar Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                MarcaNegocio negocio = new MarcaNegocio();

                negocio.eliminar(seleccionada);

                MessageBox.Show("Marca eliminada.", "Eliminar Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarMarcas();

            } else
            {
                MessageBox.Show("Selecciona una Marca para eliminar.", "Eliminar Marca", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                dgvListadoMarcas.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
