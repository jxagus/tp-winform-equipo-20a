using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_Equipo20A
{
    public partial class Form2 : Form
    {
        private Articulo articulo = null;
        public Form2()
        {
            InitializeComponent();
            Text = "Carga de datos";
            btnAgrModif.Text = "Agregar";
        }

        public Form2(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Edicion de datos";
            btnAgrModif.Text = "Modificar";
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            //convertir en titulo "Modificar" o "Agregar" dependiendo del botón que se haya presionado en el form1
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categorianegocio = new CategoriaNegocio();
            MarcaNegocio marcanegocio = new MarcaNegocio();

            try
            {
                cboCategoria.DataSource = categorianegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboMarca.DataSource = marcanegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text=articulo.Codigo;
                    txtNombre.Text=articulo.Nombre;

                    if(articulo.Imagenes != null)
                    {
                        foreach (Imagen img in articulo.Imagenes)
                        {
                            cboImagenVistaPrevia.Items.Add(img.UrlImagen);
                        }
                        if(cboImagenVistaPrevia.Items.Count > 0)
                            cboImagenVistaPrevia.SelectedIndex = 0;
                    }
                    

                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    txtPrecio.Text=articulo.Precio.ToString();
                    txtDescripcion.Text=articulo.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnAgrModif_Click(object sender, EventArgs e)
        {
            
            if (hayError())
            {
                MessageBox.Show("Error/es Detectado/s.", "Error de cargado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }else if (cboImagenVistaPrevia.Items.Count < 1)
            {
                MessageBox.Show("El articulo debe tener al menos 1 (Una) imagen subida.", "Error de cargado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if(articulo ==  null)
                    articulo = new Articulo();
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Imagenes.Clear();
                foreach (var item in cboImagenVistaPrevia.Items)
                {
                    Imagen aux = new Imagen();
                    aux.UrlImagen = item.ToString();
                    articulo.Imagenes.Add(aux);
                }
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Descripcion = txtDescripcion.Text;
                
                if(articulo.Id == 0)
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Articulo agregado con exito!");
                }
                else
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Articulo modificado con exito!");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string url = txtUrlImagen.Text;
            if (!string.IsNullOrEmpty(txtUrlImagen.Text))
            {
                cboImagenVistaPrevia.Items.Add(url);
                cboImagenVistaPrevia.SelectedIndex = cboImagenVistaPrevia.Items.Count - 1;
                txtUrlImagen.Clear();
            }
        }

        private void cboImagenVistaPrevia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = cboImagenVistaPrevia.SelectedItem.ToString();
            cargarImagen(url);
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbImagen.Load(url);
            }
            catch (Exception)
            {
                pbImagen.Load("https://img.ridingwarehouse.com/watermark/rs.php?path=-1.jpg&nw=455");
            }
        }

        private void lblAgregado_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboImagenVistaPrevia.SelectedIndex != -1)
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar esta imagen?","", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    int indice = cboImagenVistaPrevia.SelectedIndex;
                    cboImagenVistaPrevia.Items.RemoveAt(indice);
                    cargarImagen("");
                    if (cboImagenVistaPrevia.Items.Count > 0)
                    {
                        cboImagenVistaPrevia.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay imagenes para eliminar","", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (validarCodigoRepetido())
            {
                errorProvider1.SetError(txtCodigo, "No pueden haber Codigos Iguales");
                return;
            }
            if (estaVacio(txtCodigo))
            {
                errorProvider1.SetError(txtCodigo, "No pueden haber campos vacios");
                return;
            }
            errorProvider1.SetError(txtCodigo, "");
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (estaVacio(txtNombre))
            {
                errorProvider1.SetError(txtNombre, "No pueden haber campos vacios");
                return;
            }

            errorProvider1.SetError(txtNombre, "");
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            if (estaVacio(txtPrecio))
            {
                errorProvider1.SetError(txtPrecio, "No pueden haber campos vacios");
                return;
            }

            if (!validarPrecio())
            {
                errorProvider1.SetError(txtPrecio, "Precio Ingresado Invalido");
                return;
            }

            errorProvider1.SetError(txtPrecio, "");
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (estaVacio(txtDescripcion))
            {
                errorProvider1.SetError(txtDescripcion, "No pueden haber campos vacios");
                return;
            }

            errorProvider1.SetError(txtDescripcion, "");
        }

        bool validarCodigoRepetido()
        {
            ArticuloNegocio datos = new ArticuloNegocio();
            List<Articulo> todos = datos.listar();
            string codigoIngresado = txtCodigo.Text.Trim();
            foreach (Articulo aux in todos)
            {
                if (aux.Codigo.ToUpper() == codigoIngresado.ToUpper())
                {
                    if (articulo == null || aux.Id != articulo.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        bool estaVacio(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                return true;
            }
            return false;
        }

        bool validarPrecio()
        {
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                return false;
            }
            return true;
        }


        private bool hayError()
        {
            bool error = false;

            List<Control> camposVacios = new List<Control> {txtCodigo, txtNombre, txtDescripcion, txtPrecio};

            foreach (Control aux in camposVacios)
            {
                if(string.IsNullOrEmpty(aux.Text)){
                    errorProvider1.SetError(aux, "No pueden haber campos vacios");
                    error = true;
                }
                else
                {
                    errorProvider1.SetError(aux, "");
                }
            }
            if (!validarPrecio())
            {
                errorProvider1.SetError(txtPrecio, "Precio Ingresado Invalido");
                error = true;
            }
            if (validarCodigoRepetido())
            {
                errorProvider1.SetError(txtCodigo, "No pueden haber Codigos Iguales");
                error = true;
            }
            return error;
        }
    }
}
