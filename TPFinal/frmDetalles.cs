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

namespace TPFinal
{
    public partial class frmDetalles : Form
    {
        private Articulo articulo;

        public frmDetalles()
        {
            InitializeComponent();
        }

        public frmDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmDetalles_Load(object sender, EventArgs e)
        {
            lblCodigoDetalles.Text = articulo.Codigo.ToString();
            lblNombreDetalles.Text = articulo.Nombre;
            lblDescripcionDetalles.Text = articulo.Descripcion;
            lblMarcaDetalles.Text = articulo.Marca.Descripcion;
            lblCategoriaDetalles.Text = articulo.Categoria.Descripcion;
            lblPrecioDetalles.Text = "$" + articulo.Precio.ToString();
            cargarImagen(articulo.Imagen);
        }

        public void cargarImagen(string imagen)
        {
            try
            {
                pbxDetalles.Load(imagen);
            }
            catch (Exception)
            {
                pbxDetalles.Load("https://www.smaroadsafety.com/wp-content/uploads/2022/06/no-pic.png");
            }

        }
    }
}
