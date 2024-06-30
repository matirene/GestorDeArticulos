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
using System.Net;

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
            cbxCampo.Items.Add("Categoría");
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
            dgvListadoArticulos.Columns["Precio"].Visible = false;
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
                if (CheckInternetConnection())
                {
                    try
                    {
                        pbxListadoArticulos.Load("https://www.smaroadsafety.com/wp-content/uploads/2022/06/no-pic.png");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cargar la imagen default: " + ex.Message);
                    }
                } else
                {
                    // Manejamos la falta de conexión a internet para que no se rompa la App.
                    Console.WriteLine("No hay conexión a internet y no se puede cargar la imagen default.");

                }

            }
        
        }

        private bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
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
                MessageBox.Show("No hay un artículo seleccionado para ver sus detalles.", "Detalles Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Console.WriteLine(frmModificar.ImagenAnterior);
                    if (File.Exists(frmModificar.ImagenAnterior))
                        File.Delete(frmModificar.ImagenAnterior);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            } else
            {
                MessageBox.Show("No hay un artículo seleccionado para modificar.", "Modificar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListadoArticulos.CurrentRow != null)
            {

                Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar el Artículo " + seleccionado.Nombre.ToUpper() + " ?", "Eliminar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.No)
                    return;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                articuloNegocio.eliminar(seleccionado);

                MessageBox.Show("Artículo eliminado.", "Eliminar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarData();

                try
                {
                    if (File.Exists(seleccionado.Imagen))
                        File.Delete(seleccionado.Imagen);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            } else
            {
                MessageBox.Show("No hay un artículo seleccionado para eliminar.", "Eliminar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtFiltroRapido.Text.Trim().Length > 2)
            {
                List<Articulo> listaFiltrada = listaArticulos.FindAll(articulo => articulo.Codigo.ToUpper().Contains(txtFiltroRapido.Text.Trim().ToUpper()) || articulo.Nombre.ToUpper().Contains(txtFiltroRapido.Text.Trim().ToUpper()) || articulo.Marca.Descripcion.ToUpper().Contains(txtFiltroRapido.Text.Trim().ToUpper()) || articulo.Categoria.Descripcion.ToUpper().Contains(txtFiltroRapido.Text.Trim().ToUpper()));
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
                MessageBox.Show("El filtro no puede estar vacío.", "Filtro inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
