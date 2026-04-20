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

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvLista.DataSource = negocio.listar();
            ocultarColumnas();

            //dgvLista.Columns["Codigo"].DisplayIndex = 0;    //primera posición
            //dgvLista.Columns["Nombre"].DisplayIndex = 1;    //2da
            //dgvLista.Columns["Marca"].DisplayIndex = 2;     //3era
            //dgvLista.Columns["Categoria"].DisplayIndex = 3; //4ta
            //dgvLista.Columns["Descripcion"].DisplayIndex = 4; //....X
            //dgvLista.Columns["Precio"].DisplayIndex = 5;    //ultima
        }
        private void ocultarColumnas()
        {
            dgvLista.Columns["ImagenUrl"].Visible = false; //ocultamos la url
            
        }

    }
}
