using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace presentacion
{
    public partial class FrmCatalogo : Form
    {
        private List<Articulo> listaArticulo;
        public FrmCatalogo()
        {

            InitializeComponent();
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                //Oculto columnas
                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;

                //Cargo la primer imagen por defecto
                cargarImagen(listaArticulo[0].ImagenUrl);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            //Verifico que la fila actual no sea nula
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.ImagenUrl);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           FrmAltaArticulo alta = new FrmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }
    }
}
