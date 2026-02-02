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
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");

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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;

            if(filtro.Length >= 2)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                //Si borro el filtro, vuelvo a cargar la lista original
                listaFiltrada = listaArticulo;
            }
            //Limpio y recargo la grilla
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                //Verifico que la fila actual no sea nula
                if(dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("No hay ningun articulo seleccionado");
                    return;
                }
             DialogResult respuesta = MessageBox.Show("¿Seguro que desea eliminar el articulo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if(respuesta == DialogResult.No)
                {
                    return;
                }
                //Si la respuesta es si lo elimino
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                negocio.eliminar(seleccionado.Id);
                cargar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                //Obtengo el objeto que selecciono
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                FrmAltaArticulo modificar = new FrmAltaArticulo(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("No hay ningun articulo seleccionado");

            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            //Validamos que haya seleccionado una fila
            if (dgvArticulos.CurrentRow != null)
            {
                //Obtengo el articulo seleccionado
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                //Creo la ventana de detalle y le paso el articulo
                FrmDetalleArticulo detalle = new FrmDetalleArticulo(seleccionado);

                //Lo muestro
                detalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo para ver el detalle.");
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            //Si cambio de campo, validamos que mostrar en criterio
            if(opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            //Tanto el criterio Nombre como Descripcion se filtran de la misma manera
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
    }
}
