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
        public Form2()
        {
            InitializeComponent();
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
                cboMarca.DataSource = marcanegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnAgrModif_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio articulo = new ArticuloNegocio();
            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                //nuevo.ImagenUrl = txtUrlImagen.Text;
                nuevo.Imagenes.Clear(); // por si se entra en modificar en vez de agreagar
                foreach (var item in cboImagenVistaPrevia.Items)
                {
                    Imagen aux = new Imagen();
                    aux.UrlImagen = item.ToString();
                    nuevo.Imagenes.Add(aux);
                }
                nuevo.Categoria = (Categoria)cboCategoria.SelectedItem;
                nuevo.Marca = (Marca)cboMarca.SelectedItem;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                
                articulo.agregar(nuevo);
                MessageBox.Show("Articulo agregado con exito!");
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
                int indice = cboImagenVistaPrevia.SelectedIndex;
                cboImagenVistaPrevia.Items.RemoveAt(indice);
                cargarImagen("");
                if (cboImagenVistaPrevia.Items.Count > 0)
                {
                    cboImagenVistaPrevia.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("No hay imagenes para eliminar");
            }
        }
    }
}
