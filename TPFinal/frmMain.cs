using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using System.IO;

namespace TPFinal
{
    public partial class frmMain : Form
    {
        private List<Articulo> listaArticulos;
        private ArticuloNegocio negocio = new ArticuloNegocio();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cargarData();
            cargarComboBoxFiltro();
        }

        public void cargarData()
        {
            listaArticulos = negocio.listar();
            dgvListadoArticulos.DataSource = listaArticulos;
            ocultarColumnas();
        }

        public void cargarComboBoxFiltro()
        {
            cbxCampo.Items.Add("Código");
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Marca");
            cbxCampo.Items.Add("Categoria");
            cbxCampo.SelectedIndex = 0;

            cbxCriterio.Items.Add("Contiene");
            cbxCriterio.Items.Add("Empieza con");
            cbxCriterio.Items.Add("Termina con");
            cbxCriterio.SelectedIndex = 0;

        }

        public void ocultarColumnas()
        {
            dgvListadoArticulos.Columns["Id"].Visible = false;
            dgvListadoArticulos.Columns["Descripcion"].Visible = false;
            dgvListadoArticulos.Columns["Imagen"].Visible = false;
            dgvListadoArticulos.ColumnHeadersHeight = 40;
        }

        public void cargarImagen(string imagen)
        {
            try
            {
                pbxListadoArticulos.Load(imagen);
            }
            catch (Exception)
            {
                pbxListadoArticulos.Load("https://www.smaroadsafety.com/wp-content/uploads/2022/06/no-pic.png");
            }
        
        }

        private void dgvListadoArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvListadoArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                cargarImagen(seleccionado.Imagen);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarData();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if(dgvListadoArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                frmDetalles frmDetalles = new frmDetalles(seleccionado);
                frmDetalles.ShowDialog();
            } else
            {
                MessageBox.Show("No hay un articulo seleccionado para ver sus detalles", "Detalles Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frmAltaArticulo = new frmAltaArticulo();
            frmAltaArticulo.ShowDialog();
            cargarData();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvListadoArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                frmModificar frmModificar = new frmModificar(seleccionado);
                frmModificar.ShowDialog();

                cargarData();

                try
                {
                    if (File.Exists(frmModificar.ImagenAnterior))
                        File.Delete(frmModificar.ImagenAnterior);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            } else
            {
                MessageBox.Show("No hay un articulo seleccionado para modificar.", "Modificar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListadoArticulos.CurrentRow != null)
            {

                Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar el Articulo " + seleccionado.Nombre.ToUpper() + " ?", "Eliminar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.No)
                    return;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                articuloNegocio.eliminar(seleccionado);

                MessageBox.Show("Articulo eliminado.", "Eliminar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarData();

                if (File.Exists(seleccionado.Imagen))
                    File.Delete(seleccionado.Imagen);

            } else
            {
                MessageBox.Show("No hay un articulo seleccionado para eliminar.", "Eliminar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcas = new frmMarcas();
            frmMarcas.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias();
            frmCategorias.ShowDialog();
        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroRapido.Text.Length > 2)
            {
                List<Articulo> listaFiltrada = listaArticulos.FindAll(articulo => articulo.Codigo.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || articulo.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || articulo.Marca.Descripcion.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || articulo.Categoria.Descripcion.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
                dgvListadoArticulos.DataSource = listaFiltrada; 
            } else
            {
                dgvListadoArticulos.DataSource = listaArticulos;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                string campo = cbxCampo.SelectedItem.ToString();
                string criterio = cbxCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text.Trim();

                dgvListadoArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                ocultarColumnas();

            } else
            {
                MessageBox.Show("El filtro no puede estar vacio", "Filtro invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
