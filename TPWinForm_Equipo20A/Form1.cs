using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPWinForm_Equipo20A
{
    public partial class Form1 : Form

    {
        private List<Articulo> listaArticulo;

        public Form1()
        {
            InitializeComponent();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cbCampo.Items.Add("Precio");
            cbCampo.Items.Add("Nombre");
            cbCampo.Items.Add("Categoria");
            cbCampo.Items.Add("Marca");
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            listaArticulo = negocio.listar();
            dgvLista.DataSource = listaArticulo;

            if (listaArticulo.Count > 0 &&
                listaArticulo[0].Imagenes != null &&
                listaArticulo[0].Imagenes.Count > 0)
            {
                pbImagen.Load(listaArticulo[0].Imagenes[0].UrlImagen);
            }

            ocultarColumnas();
        }
        private void ocultarColumnas()
        {
            dgvLista.Columns["Id"].Visible = false;
            //dgvLista.Columns["ImagenUrl"].Visible = false; //ocultamos la url           
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
    }
}
