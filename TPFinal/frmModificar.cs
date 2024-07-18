using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    public partial class frmModificar : Form
    {
        private Articulo articulo;

        private OpenFileDialog archivo = null;

        public string ImagenAnterior { get; set; }

        public string ImagenActual { get; set; }

        public frmModificar()
        {
            InitializeComponent();
        }
        public frmModificar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }


        private void frmModificar_Load(object sender, EventArgs e)
        {
            cargarComboBoxs();
            cargarData();
            cargarImagenBoton("https://cdn-icons-png.flaticon.com/512/1160/1160358.png");
        }

        private void btnAceptarModificar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
                return;

            DialogResult respuesta = MessageBox.Show("Estas seguro de modificar el Articulo?", "Modificar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
                return;

            try
            {
                Articulo articuloAux = new Articulo();

                articuloAux.Id = articulo.Id;
                articuloAux.Codigo = txtCodigoModificar.Text;
                articuloAux.Nombre = txtNombreModificar.Text;
                articuloAux.Descripcion = txtDescripcionModificar.Text;
                articuloAux.Marca = (Marca)cbxMarcaModificar.SelectedItem;
                articuloAux.Categoria = (Categoria)cbxCategoriaModificar.SelectedItem;
                articuloAux.Precio = decimal.Parse(txtPrecioModificar.Text);

                ImagenAnterior = articulo.Imagen;

                if(archivo != null && !txtImagenModificar.Text.Trim().ToUpper().Contains("HTTP"))
                {

                    string extension = Path.GetExtension(archivo.SafeFileName);

                    string nuevoNombreArchivo = Path.GetFileNameWithoutExtension(archivo.SafeFileName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;

                    string path = Path.Combine(CarpetaImagenesManager.FolderPath, nuevoNombreArchivo);

                    File.Copy(archivo.FileName, path);

                    articuloAux.Imagen = path;

                } else
                {
                    articuloAux.Imagen = txtImagenModificar.Text;
                }

                ImagenActual = articuloAux.Imagen;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                articuloNegocio.modificar(articuloAux);

                MessageBox.Show("Articulo modificado.", "Modificar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void cargarData()
        {
            txtCodigoModificar.Text = articulo.Codigo;
            txtNombreModificar.Text = articulo.Nombre;
            txtDescripcionModificar.Text = articulo.Descripcion;
            txtImagenModificar.Text = articulo.Imagen;
            cargarImagen(articulo.Imagen);
            cbxMarcaModificar.SelectedValue = articulo.Marca.Id;
            cbxCategoriaModificar.SelectedValue = articulo.Categoria.Id;
            txtPrecioModificar.Text = articulo.Precio.ToString();
        }

        private void cargarComboBoxs()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cbxMarcaModificar.DataSource = marcaNegocio.listar();
            cbxMarcaModificar.ValueMember = "Id";
            cbxMarcaModificar.DisplayMember = "Descripcion";

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cbxCategoriaModificar.DataSource = categoriaNegocio.listar();
            cbxCategoriaModificar.ValueMember = "Id";
            cbxCategoriaModificar.DisplayMember = "Descripcion";
        }

        public void cargarImagen(string imagen)
        {
            try
            {
                if (!txtImagenModificar.Text.Trim().ToUpper().Contains("HTTP"))
                {
                    pbxImagenModificar.Image = LoadImageCopy(imagen);

                } else
                {
                    pbxImagenModificar.Load(imagen);
                }

            }
            catch (WebException)
            {
                pbxImagenModificar.Image = pbxImagenModificar.ErrorImage;
            }
            catch (FileNotFoundException)
            {
                pbxImagenModificar.Image = pbxImagenModificar.ErrorImage;
            }
            catch (DirectoryNotFoundException)
            {
                pbxImagenModificar.Image = pbxImagenModificar.ErrorImage;
            }
        }

        private Image LoadImageCopy(string imagePath)
        {
            // Crear una copia local de la imagen.
            using (Image originalImage = Image.FromFile(imagePath))
            {
                // Retornar una nueva instancia (COPIA) de la imagen.
                return new Bitmap(originalImage);
            }
        }



        public void cargarImagenBoton(string imagen)
        {
            try
            {
                pbxBuscarImgModificar.Load(imagen);
            }
            catch (Exception)
            {
                pbxBuscarImgModificar.Image = pbxBuscarImgModificar.ErrorImage;
            }
        }

        private void pbxBuscarImgModificar_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbxBuscarImgModificar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelarModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImagenModificar_TextChanged(object sender, EventArgs e)
        {
            cargarImagen(txtImagenModificar.Text);
        }

        private void pbxBuscarImgModificar_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "(*.jpg; *.png)|*.jpg; *.png;";
            archivo.Title = "Agregar Imagen";

            if(archivo.ShowDialog() == DialogResult.OK)
                txtImagenModificar.Text = archivo.FileName;
        }

        private bool validarCampos()
        {
            Validacion validacion = new Validacion();

            if (validacion.isEmpty(txtCodigoModificar.Text) || validacion.isEmpty(txtNombreModificar.Text) || validacion.isEmpty(txtPrecioModificar.Text))
            {
                MessageBox.Show("Campos incompletos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (!validacion.onlyNumbers(txtPrecioModificar.Text))
            {
                MessageBox.Show("Solo se permiten numeros en el campo Precio.", "Campo invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

    }
}
