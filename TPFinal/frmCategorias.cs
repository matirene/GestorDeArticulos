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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            dgvListadoCategorias.DataSource =  negocio.listar();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmAltaCategoria frmAltaCategoria = new frmAltaCategoria();
            frmAltaCategoria.ShowDialog();
            cargarCategorias();
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if(dgvListadoCategorias.CurrentRow != null)
            {
                DialogResult respuesta = MessageBox.Show("Confirmas eliminar esta Categoria?", "Eliminar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                Categoria seleccionada = (Categoria)dgvListadoCategorias.CurrentRow.DataBoundItem;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = articuloNegocio.listar();

                foreach (Articulo a in listaArticulos)
                {
                    if(a.Categoria.Descripcion.ToUpper() == seleccionada.Descripcion.ToUpper())
                    {
                        MessageBox.Show("No se puede eliminar. Hay articulos registrados con la Categoria " + seleccionada.Descripcion, "Eliminar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                categoriaNegocio.eliminar(seleccionada);

                MessageBox.Show("Categoria eliminada", "Eliminar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarCategorias();
            }

        }
    }
}
