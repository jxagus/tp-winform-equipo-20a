namespace TPWinForm_Equipo20A
{
    partial class Form2
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAgrModif = new System.Windows.Forms.Button();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.lblAgregado = new System.Windows.Forms.Label();
            this.cboImagenVistaPrevia = new System.Windows.Forms.ComboBox();
            this.btnBorrarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(93, 83);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(96, 221);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 1;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(70, 247);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(89, 109);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Location = new System.Drawing.Point(91, 140);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(45, 13);
            this.lblImagen.TabIndex = 4;
            this.lblImagen.Text = "Imagen:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(81, 166);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoria:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(96, 194);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(156, 163);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(200, 21);
            this.cboCategoria.TabIndex = 4;
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(156, 191);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(200, 21);
            this.cboMarca.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(156, 244);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(156, 106);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(156, 137);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(200, 20);
            this.txtUrlImagen.TabIndex = 2;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(156, 218);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(200, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(156, 80);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCancelar.Location = new System.Drawing.Point(654, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Salir/Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(459, 73);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(222, 191);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 15;
            this.pbImagen.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(254, 32);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(10, 13);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = " ";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // btnAgrModif
            // 
            this.btnAgrModif.Location = new System.Drawing.Point(257, 283);
            this.btnAgrModif.Name = "btnAgrModif";
            this.btnAgrModif.Size = new System.Drawing.Size(99, 23);
            this.btnAgrModif.TabIndex = 9;
            this.btnAgrModif.Text = "A/M";
            this.btnAgrModif.UseVisualStyleBackColor = true;
            this.btnAgrModif.Click += new System.EventHandler(this.btnAgrModif_Click);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(362, 137);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarImagen.TabIndex = 3;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // lblAgregado
            // 
            this.lblAgregado.AutoSize = true;
            this.lblAgregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregado.Location = new System.Drawing.Point(458, 274);
            this.lblAgregado.Name = "lblAgregado";
            this.lblAgregado.Size = new System.Drawing.Size(66, 13);
            this.lblAgregado.TabIndex = 18;
            this.lblAgregado.Text = "Vista Previa:";
            this.lblAgregado.Click += new System.EventHandler(this.lblAgregado_Click);
            // 
            // cboImagenVistaPrevia
            // 
            this.cboImagenVistaPrevia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImagenVistaPrevia.FormattingEnabled = true;
            this.cboImagenVistaPrevia.Location = new System.Drawing.Point(524, 271);
            this.cboImagenVistaPrevia.Name = "cboImagenVistaPrevia";
            this.cboImagenVistaPrevia.Size = new System.Drawing.Size(128, 21);
            this.cboImagenVistaPrevia.TabIndex = 8;
            this.cboImagenVistaPrevia.SelectedIndexChanged += new System.EventHandler(this.cboImagenVistaPrevia_SelectedIndexChanged);
            // 
            // btnBorrarImagen
            // 
            this.btnBorrarImagen.Location = new System.Drawing.Point(655, 270);
            this.btnBorrarImagen.Name = "btnBorrarImagen";
            this.btnBorrarImagen.Size = new System.Drawing.Size(24, 23);
            this.btnBorrarImagen.TabIndex = 19;
            this.btnBorrarImagen.Text = "🗑️";
            this.btnBorrarImagen.UseVisualStyleBackColor = true;
            this.btnBorrarImagen.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 345);
            this.Controls.Add(this.btnBorrarImagen);
            this.Controls.Add(this.cboImagenVistaPrevia);
            this.Controls.Add(this.lblAgregado);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.btnAgrModif);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de Datos";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgrModif;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Label lblAgregado;
        private System.Windows.Forms.ComboBox cboImagenVistaPrevia;
        private System.Windows.Forms.Button btnBorrarImagen;
    }
}