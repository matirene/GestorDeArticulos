namespace TPFinal
{
    partial class frmAltaCategoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaCategoria));
            this.btnCancelarAltaCat = new System.Windows.Forms.Button();
            this.btnAceptarAltaCat = new System.Windows.Forms.Button();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelarAltaCat
            // 
            this.btnCancelarAltaCat.Location = new System.Drawing.Point(189, 152);
            this.btnCancelarAltaCat.Name = "btnCancelarAltaCat";
            this.btnCancelarAltaCat.Size = new System.Drawing.Size(99, 31);
            this.btnCancelarAltaCat.TabIndex = 14;
            this.btnCancelarAltaCat.Text = "Cancelar";
            this.btnCancelarAltaCat.UseVisualStyleBackColor = true;
            this.btnCancelarAltaCat.Click += new System.EventHandler(this.btnCancelarAltaCat_Click);
            // 
            // btnAceptarAltaCat
            // 
            this.btnAceptarAltaCat.Location = new System.Drawing.Point(57, 152);
            this.btnAceptarAltaCat.Name = "btnAceptarAltaCat";
            this.btnAceptarAltaCat.Size = new System.Drawing.Size(99, 31);
            this.btnAceptarAltaCat.TabIndex = 13;
            this.btnAceptarAltaCat.Text = "Aceptar";
            this.btnAceptarAltaCat.UseVisualStyleBackColor = true;
            this.btnAceptarAltaCat.Click += new System.EventHandler(this.btnAceptarAltaCat_Click);
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCategoria.Location = new System.Drawing.Point(57, 79);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(231, 26);
            this.txtNombreCategoria.TabIndex = 11;
            // 
            // lblNombreCategoria
            // 
            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNombreCategoria.Location = new System.Drawing.Point(53, 45);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Size = new System.Drawing.Size(65, 20);
            this.lblNombreCategoria.TabIndex = 12;
            this.lblNombreCategoria.Text = "Nombre";
            // 
            // frmAltaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 229);
            this.Controls.Add(this.btnCancelarAltaCat);
            this.Controls.Add(this.btnAceptarAltaCat);
            this.Controls.Add(this.txtNombreCategoria);
            this.Controls.Add(this.lblNombreCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAltaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarAltaCat;
        private System.Windows.Forms.Button btnAceptarAltaCat;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.Label lblNombreCategoria;
    }
}