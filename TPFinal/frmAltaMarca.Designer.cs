namespace TPFinal
{
    partial class frmAltaMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaMarca));
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.lblNombreMarca = new System.Windows.Forms.Label();
            this.btnCancelarAltaMarca = new System.Windows.Forms.Button();
            this.btnAceptarAltaMarca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreMarca.Location = new System.Drawing.Point(50, 72);
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(231, 26);
            this.txtNombreMarca.TabIndex = 1;
            // 
            // lblNombreMarca
            // 
            this.lblNombreMarca.AutoSize = true;
            this.lblNombreMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNombreMarca.Location = new System.Drawing.Point(46, 38);
            this.lblNombreMarca.Name = "lblNombreMarca";
            this.lblNombreMarca.Size = new System.Drawing.Size(65, 20);
            this.lblNombreMarca.TabIndex = 2;
            this.lblNombreMarca.Text = "Nombre";
            // 
            // btnCancelarAltaMarca
            // 
            this.btnCancelarAltaMarca.Location = new System.Drawing.Point(182, 145);
            this.btnCancelarAltaMarca.Name = "btnCancelarAltaMarca";
            this.btnCancelarAltaMarca.Size = new System.Drawing.Size(99, 31);
            this.btnCancelarAltaMarca.TabIndex = 10;
            this.btnCancelarAltaMarca.Text = "Cancelar";
            this.btnCancelarAltaMarca.UseVisualStyleBackColor = true;
            this.btnCancelarAltaMarca.Click += new System.EventHandler(this.btnCancelarAltaMarca_Click);
            // 
            // btnAceptarAltaMarca
            // 
            this.btnAceptarAltaMarca.Location = new System.Drawing.Point(50, 145);
            this.btnAceptarAltaMarca.Name = "btnAceptarAltaMarca";
            this.btnAceptarAltaMarca.Size = new System.Drawing.Size(99, 31);
            this.btnAceptarAltaMarca.TabIndex = 9;
            this.btnAceptarAltaMarca.Text = "Aceptar";
            this.btnAceptarAltaMarca.UseVisualStyleBackColor = true;
            this.btnAceptarAltaMarca.Click += new System.EventHandler(this.btnAceptarAltaMarca_Click);
            // 
            // frmAltaMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 229);
            this.Controls.Add(this.btnCancelarAltaMarca);
            this.Controls.Add(this.btnAceptarAltaMarca);
            this.Controls.Add(this.txtNombreMarca);
            this.Controls.Add(this.lblNombreMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAltaMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Label lblNombreMarca;
        private System.Windows.Forms.Button btnCancelarAltaMarca;
        private System.Windows.Forms.Button btnAceptarAltaMarca;
    }
}