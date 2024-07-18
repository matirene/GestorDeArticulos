namespace TPFinal
{
    partial class frmConfiguaracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguaracion));
            this.lblCambiarImg = new System.Windows.Forms.Label();
            this.txtCambiarImg = new System.Windows.Forms.TextBox();
            this.btnCambiarCarpetaImg = new System.Windows.Forms.Button();
            this.btnCambiarServidor = new System.Windows.Forms.Button();
            this.txtCambiarServidor = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.btnCambiarDB = new System.Windows.Forms.Button();
            this.txtCambiarDB = new System.Windows.Forms.TextBox();
            this.lblCambiarDB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCambiarImg
            // 
            this.lblCambiarImg.AutoSize = true;
            this.lblCambiarImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambiarImg.Location = new System.Drawing.Point(29, 41);
            this.lblCambiarImg.Name = "lblCambiarImg";
            this.lblCambiarImg.Size = new System.Drawing.Size(163, 20);
            this.lblCambiarImg.TabIndex = 0;
            this.lblCambiarImg.Text = "Carpeta de Imagenes";
            // 
            // txtCambiarImg
            // 
            this.txtCambiarImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambiarImg.Location = new System.Drawing.Point(33, 74);
            this.txtCambiarImg.Name = "txtCambiarImg";
            this.txtCambiarImg.ReadOnly = true;
            this.txtCambiarImg.Size = new System.Drawing.Size(434, 26);
            this.txtCambiarImg.TabIndex = 1;
            // 
            // btnCambiarCarpetaImg
            // 
            this.btnCambiarCarpetaImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarCarpetaImg.Location = new System.Drawing.Point(490, 67);
            this.btnCambiarCarpetaImg.Name = "btnCambiarCarpetaImg";
            this.btnCambiarCarpetaImg.Size = new System.Drawing.Size(83, 33);
            this.btnCambiarCarpetaImg.TabIndex = 2;
            this.btnCambiarCarpetaImg.Text = "Cambiar";
            this.btnCambiarCarpetaImg.UseVisualStyleBackColor = true;
            this.btnCambiarCarpetaImg.Click += new System.EventHandler(this.btnCambiarCarpetaImg_Click);
            // 
            // btnCambiarServidor
            // 
            this.btnCambiarServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarServidor.Location = new System.Drawing.Point(490, 173);
            this.btnCambiarServidor.Name = "btnCambiarServidor";
            this.btnCambiarServidor.Size = new System.Drawing.Size(83, 33);
            this.btnCambiarServidor.TabIndex = 5;
            this.btnCambiarServidor.Text = "Cambiar";
            this.btnCambiarServidor.UseVisualStyleBackColor = true;
            this.btnCambiarServidor.Click += new System.EventHandler(this.btnCambiarServidor_Click);
            // 
            // txtCambiarServidor
            // 
            this.txtCambiarServidor.Enabled = false;
            this.txtCambiarServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambiarServidor.Location = new System.Drawing.Point(33, 180);
            this.txtCambiarServidor.Name = "txtCambiarServidor";
            this.txtCambiarServidor.ReadOnly = true;
            this.txtCambiarServidor.Size = new System.Drawing.Size(434, 26);
            this.txtCambiarServidor.TabIndex = 4;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidor.Location = new System.Drawing.Point(29, 147);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(67, 20);
            this.lblServidor.TabIndex = 3;
            this.lblServidor.Text = "Servidor";
            // 
            // btnCambiarDB
            // 
            this.btnCambiarDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarDB.Location = new System.Drawing.Point(490, 258);
            this.btnCambiarDB.Name = "btnCambiarDB";
            this.btnCambiarDB.Size = new System.Drawing.Size(83, 33);
            this.btnCambiarDB.TabIndex = 8;
            this.btnCambiarDB.Text = "Cambiar";
            this.btnCambiarDB.UseVisualStyleBackColor = true;
            this.btnCambiarDB.Click += new System.EventHandler(this.btnCambiarDB_Click);
            // 
            // txtCambiarDB
            // 
            this.txtCambiarDB.Enabled = false;
            this.txtCambiarDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambiarDB.Location = new System.Drawing.Point(33, 265);
            this.txtCambiarDB.Name = "txtCambiarDB";
            this.txtCambiarDB.ReadOnly = true;
            this.txtCambiarDB.Size = new System.Drawing.Size(434, 26);
            this.txtCambiarDB.TabIndex = 7;
            // 
            // lblCambiarDB
            // 
            this.lblCambiarDB.AutoSize = true;
            this.lblCambiarDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambiarDB.Location = new System.Drawing.Point(29, 232);
            this.lblCambiarDB.Name = "lblCambiarDB";
            this.lblCambiarDB.Size = new System.Drawing.Size(115, 20);
            this.lblCambiarDB.TabIndex = 6;
            this.lblCambiarDB.Text = "Base de Datos";
            // 
            // frmConfiguaracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 368);
            this.Controls.Add(this.btnCambiarDB);
            this.Controls.Add(this.txtCambiarDB);
            this.Controls.Add(this.lblCambiarDB);
            this.Controls.Add(this.btnCambiarServidor);
            this.Controls.Add(this.txtCambiarServidor);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.btnCambiarCarpetaImg);
            this.Controls.Add(this.txtCambiarImg);
            this.Controls.Add(this.lblCambiarImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfiguaracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfiguaracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCambiarImg;
        private System.Windows.Forms.TextBox txtCambiarImg;
        private System.Windows.Forms.Button btnCambiarCarpetaImg;
        private System.Windows.Forms.Button btnCambiarServidor;
        private System.Windows.Forms.TextBox txtCambiarServidor;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Button btnCambiarDB;
        private System.Windows.Forms.TextBox txtCambiarDB;
        private System.Windows.Forms.Label lblCambiarDB;
    }
}