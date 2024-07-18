using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace TPFinal
{
    public partial class frmConfiguaracion : Form
    {
        public frmConfiguaracion()
        {
            InitializeComponent();
        }

        private void frmConfiguaracion_Load(object sender, EventArgs e)
        {
            txtCambiarImg.Text = CarpetaImagenesManager.FolderPath;

            txtCambiarServidor.Text = ConfigurationManager.AppSettings["ServerName"];

            txtCambiarDB.Text = ConfigurationManager.AppSettings["DatabaseName"];
        }

        private void btnCambiarCarpetaImg_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                CarpetaImagenesManager.changeFolderPath(folderBrowserDialog.SelectedPath);
               txtCambiarImg.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnCambiarServidor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No tenes permiso para modificar el Servidor. Contactate con el Desarrollador.", "Modificar Servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCambiarDB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No tenes permiso para modificar la Base de Datos. Contactate con el Desarrollador.", "Modificar Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
