using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    public partial class frmAltaArticulo : Form
    {
        private OpenFileDialog archivo = null;

        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            cargarComboBoxs();
            pbxBuscarImagenAlta.Load("https://cdn-icons-png.flaticon.com/512/1160/1160358.png");
        }

        private void btnAceptarAlta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
                return;

            DialogResult respuesta = MessageBox.Show("Estas seguro de agregar este Articulo?", "Agregar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            Articulo articuloAux = new Articulo();

            try
            {

                articuloAux.Codigo = txtCodigoAlta.Text;
                articuloAux.Nombre = txtNombreAlta.Text;
                articuloAux.Descripcion = txtDescripcionAlta.Text;
                articuloAux.Marca = (Marca)cbxMarcaAlta.SelectedItem; 
                articuloAux.Categoria = (Categoria)cbxCategoriaAlta.SelectedItem;
                articuloAux.Precio = decimal.Parse(txtPrecioAlta.Text);

                if(archivo != null && !txtImagenAlta.Text.Trim().ToUpper().Contains("HTTP"))
                {
                    string extension = Path.GetExtension(archivo.SafeFileName);

                    string nuevoNombreArchivo = Path.GetFileNameWithoutExtension(archivo.SafeFileName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;

                    string path = getPath(nuevoNombreArchivo);

                    File.Copy(archivo.FileName, path);

                    articuloAux.Imagen = path;

                } else
                {
                    articuloAux.Imagen = txtImagenAlta.Text;
                }

                articuloNegocio.agregar(articuloAux);

                MessageBox.Show("Articulo agregado.", "Agregar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void cargarImagen(string imagen)
        {
            try
            {
                pbxImagenAlta.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagenAlta.Load("https://www.smaroadsafety.com/wp-content/uploads/2022/06/no-pic.png");
            }
        }

        private void pbxBuscarImagenAlta_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbxBuscarImagenAlta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor= Cursors.Default;
        }

        private void cargarComboBoxs()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cbxMarcaAlta.DataSource = marcaNegocio.listar();
            cbxMarcaAlta.ValueMember = "Id";
            cbxMarcaAlta.DisplayMember = "Descripcion";

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cbxCategoriaAlta.DataSource = categoriaNegocio.listar();
            cbxCategoriaAlta.ValueMember = "Id";
            cbxCategoriaAlta.DisplayMember = "Descripcion";
        }

        private void btnCancelarAlta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbxBuscarImagenAlta_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "(*.jpg; *.png)|*.jpg; *.png;";
            archivo.Title = "Agregar Imagen";

            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagenAlta.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }

        private void txtImagenAlta_TextChanged(object sender, EventArgs e)
        {
            cargarImagen(txtImagenAlta.Text);
        }

        private string getPath(string fileName)
        {
            string pathDirectory = Environment.CurrentDirectory;
            string pathFather = System.IO.Directory.GetParent(pathDirectory).Parent.FullName;

            string pathImagenes = Path.Combine(pathFather, "Imagenes\\");

            string pathFinal = Path.Combine(pathImagenes, fileName);

            return pathFinal;

        }

        private bool validarCampos()
        {
            Validacion validacion = new Validacion();

            if (validacion.isEmpty(txtCodigoAlta.Text) || validacion.isEmpty(txtNombreAlta.Text) || validacion.isEmpty(txtPrecioAlta.Text))
            {
                MessageBox.Show("Campos incompletos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (!validacion.onlyNumbers(txtPrecioAlta.Text))
            {
                MessageBox.Show("Solo se permiten numeros en el campo Precio.", "Campo invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        private void txtPrecioAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Limita el campo a que ingresen solo numeros.
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
