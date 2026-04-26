using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPWinForm_Equipo20A
{

    public partial class Form1 : Form

    {
        private List<Articulo> listaArticulo;
        private Articulo articulo = null;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cbCampo.Items.Add("Precio");
            cbCampo.Items.Add("Nombre");
            cbCampo.Items.Add("Categoria");
            cbCampo.Items.Add("Marca");
            ImagenNegocio img = new ImagenNegocio();
            try
            {
                cboImagenVistaPrevia.DataSource = img.listar(listaArticulo[0].Id);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            { 
                listaArticulo = negocio.listar();

                dgvLista.DataSource = listaArticulo;

                ocultarColumnas();

                if (listaArticulo != null && listaArticulo.Count > 0)
                {
                    if (listaArticulo[0].Imagenes != null && listaArticulo[0].Imagenes.Count > 0)
                    {
                        cargarImagen(listaArticulo[0].Imagenes[0].UrlImagen);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga: " + ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            if (dgvLista.Columns["Imagenes"] != null) dgvLista.Columns["Imagenes"].Visible = false;
            if (dgvLista.Columns["Id"] != null) dgvLista.Columns["Id"].Visible = false;

            if (dgvLista.Columns["Marca"] != null) dgvLista.Columns["Marca"].Visible = false;
            if (dgvLista.Columns["Categoria"] != null) dgvLista.Columns["Categoria"].Visible = false;

            /*if (dgvLista.Columns["Precio"] != null)
                dgvLista.Columns["Precio"].DefaultCellStyle.Format = "N3";*/
        }
        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null)
                return;

            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            if (seleccionado != null)
            {
                cboImagenVistaPrevia.DataSource = null;

                if (seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
                {
                    cboImagenVistaPrevia.DataSource = seleccionado.Imagenes;
                    cboImagenVistaPrevia.DisplayMember = "UrlImagen";
                }
                else
                {
                    cargarImagen("");
                }
            }
        }

        private void cboImagenVistaPrevia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Imagen seleccionada = cboImagenVistaPrevia.SelectedItem as Imagen;

            if (seleccionada != null && !string.IsNullOrEmpty(seleccionada.UrlImagen))
            {
                cargarImagen(seleccionada.UrlImagen);
            }
            else
            {
                cargarImagen("");
            }
        }
        private void cargarImagen(string url)
        {
            try
            {
                pbImagen.Load(url);
            }
            catch (Exception ex)
            {
                //Nota: En la debe solo hay 2 imagenes que fincionan y otra esta restringida por su pagina y no la puede leer la app
                //agregue la linea de abajo para que vean la salida de la app que les dice que las url estan prohibidas o desparecidas o etc
                Console.WriteLine("Error crítico de imagen: " + ex.Message);
                pbImagen.Load("https://img.ridingwarehouse.com/watermark/rs.php?path=-1.jpg&nw=455");
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form2 agregar = new Form2();
            agregar.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            ImagenNegocio img = new ImagenNegocio();
            seleccionado.Imagenes = img.listar(seleccionado.Id);

            Form2 modificar = new Form2(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            cargar();
        }


        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Mayor a");
                cbCriterio.Items.Add("Menor a");
            }
            else
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Comienza con");
                cbCriterio.Items.Add("Termina con");
                cbCriterio.Items.Add("Contiene");
            }
        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            if (cbCampo.SelectedItem == null || cbCriterio.SelectedItem == null)
            {
                MessageBox.Show("Antes de realizar la busqueda, ingresar campo y criterio.");
                return; 
            }
            if (cbCampo.SelectedItem.ToString() == "Precio")
            {
                if (!decimal.TryParse(txtBusquedaAvanzada.Text, out decimal valor))
                {
                    MessageBox.Show("Para el campo Precio, ingresá solo números");
                    return;
                }
            }

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                string campo = cbCampo.SelectedItem.ToString();
                string criterio = cbCriterio.SelectedItem.ToString();
                string filtro = txtBusquedaAvanzada.Text;
                dgvLista.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (listaArticulo == null) return;

            try
            {
                string filtro = txtBuscar.Text;
                List<Articulo> listaFiltrada;

                if (filtro.Length >= 2)
                {
                    listaFiltrada = listaArticulo.FindAll(x => x.Nombre != null &&  x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {

                    listaFiltrada = listaArticulo;
                }

                dgvLista.DataSource = null;
                dgvLista.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                if (dgvLista.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un artículo primero");
                    return;
                }
                seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                DialogResult repuesta = MessageBox.Show("Confirmar el DELETE de: " + seleccionado.Nombre, "Eliminando",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (repuesta == DialogResult.Yes)
                {
                    negocio.Eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLista.Columns[e.ColumnIndex].Name == "Precio" && e.Value != null)
            {
                if (e.Value is decimal precio)
                {
                    // Multiplicamos por 100 y vemos si queda resto
                    if ((precio * 100) % 1 != 0)
                    {
                        // Tiene 3 o más decimales significativos
                        e.Value = precio.ToString("C3");
                    }
                    else
                    {
                        // Es un precio estándar: usamos C2
                        e.Value = precio.ToString("C2");
                    }                   
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
