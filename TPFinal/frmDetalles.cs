using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            catch (Exception)
            {
                if (CheckInternetConnection())
                {
                    try
                    {
                        pbxDetalles.Load("https://www.smaroadsafety.com/wp-content/uploads/2022/06/no-pic.png");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cargar la imagen default: " + ex.Message);
                    }
                }
                else
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

    }
}
