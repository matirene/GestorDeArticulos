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
        }

        public void cargarData()
        {
            listaArticulos = negocio.listar();
            dgvListadoArticulos.DataSource = listaArticulos;
            ocultarColumnas();
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
            Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

            cargarImagen(seleccionado.Imagen);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarData();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

            frmDetalles frmDetalles = new frmDetalles(seleccionado);
            frmDetalles.ShowDialog();
        }
    }
}
