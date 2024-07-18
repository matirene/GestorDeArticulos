using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
            lblPrecioDetalles.Text = articulo.Precio.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"));
            cargarImagen(articulo.Imagen);
        }

        public void cargarImagen(string imagen)
        {
            try
            {
                pbxDetalles.Load(imagen);
            }
            catch (WebException)
            {
                pbxDetalles.Image = pbxDetalles.ErrorImage;
            }
            catch (FileNotFoundException)
            {
                pbxDetalles.Image = pbxDetalles.ErrorImage;
            }
            catch (DirectoryNotFoundException)
            {
                pbxDetalles.Image = pbxDetalles.ErrorImage;
            }
        }

    }
}
