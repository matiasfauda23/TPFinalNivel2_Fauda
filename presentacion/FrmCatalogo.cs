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
using FontAwesome.Sharp; 
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Controls;

namespace presentacion
{
    public partial class FrmCatalogo : MaterialForm
    {
        private List<Articulo> listaArticulo;
        public FrmCatalogo()
        {
            cargarColorPrincipal();
            InitializeComponent();
            //Configuracion de MaterialSkin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {
            cargar();
            personalizarDiseño();
            cboCampo.Items.Clear(); 
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");

            // Boton de buscar
            btnFiltro.Image = IconChar.Search.ToBitmap(Color.Black, 30);
            btnFiltro.TextImageRelation = TextImageRelation.ImageBeforeText; 

            // Boton de agregar
            btnAgregar.Image = IconChar.Plus.ToBitmap(Color.Green, 30);

            // Boton de modificar
            btnModificar.Image = IconChar.Pen.ToBitmap(Color.SteelBlue, 30); 

            // Boton de eliminar
            btnEliminar.Image = IconChar.TrashAlt.ToBitmap(Color.Red, 30); 

            //Boton de limpiar
            btnLimpiar.Image = IconChar.Broom.ToBitmap(Color.Black, 30);
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText; 
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

                //Formato de moneda a la columna precio
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2"; 

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
            cargarColorPrincipal();
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
                MessageBox.Show("El articulo fue eliminado con exito");

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
                cargarColorPrincipal();
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
            if (cboCampo.SelectedItem != null)
            {
                string opcion = cboCampo.SelectedItem.ToString();

                if (opcion == "Precio")
                {
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Mayor a");
                    cboCriterio.Items.Add("Menor a");
                    cboCriterio.Items.Add("Igual a");
                }
                else
                {
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    cboCriterio.Items.Add("Contiene");
                }
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                // Validaciones para evitar que explote si el usuario no elige nada
                if (cboCampo.SelectedIndex < 0)
                {
                    MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                    return;
                }

                if (cboCriterio.SelectedIndex < 0)
                {
                    MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                    return;
                }

                // Validacion de numeros
                if (cboCampo.SelectedItem.ToString() == "Precio")
                {
                    if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                    {
                        MessageBox.Show("Debes cargar un número para filtrar por precio.");
                        return;
                    }
                    if (!(soloNumeros(txtFiltroAvanzado.Text)))
                    {
                        MessageBox.Show("Solo nros para filtrar por campo numérico.");
                        return;
                    }
                }

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                //Filtramos
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                // Si encontramos UN solo caracter que no sea número, devolvemos falso
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            // Si recorrimos todo y no falló, es porque son todos números
            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargar();
            //Limpieza visual
            txtFiltroAvanzado.Text = "";
            cboCampo.SelectedIndex = -1;
            cboCriterio.SelectedIndex = -1;
        }

        private void personalizarDiseño()
        {
            dgvArticulos.RowHeadersVisible = false;
            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
            dgvArticulos.AllowUserToResizeColumns = false;
            dgvArticulos.AllowUserToResizeRows = false;

            
            dgvArticulos.BackgroundColor = System.Drawing.Color.White; 

            
            dgvArticulos.EnableHeadersVisualStyles = false; 
            dgvArticulos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(64, 64, 64); 
            dgvArticulos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; 
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); 
            dgvArticulos.ColumnHeadersHeight = 30;

            dgvArticulos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue; 
            dgvArticulos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }


        private void cargarColorPrincipal()
        {
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(
                Primary.BlueGrey300,
                Primary.BlueGrey500,
                Primary.BlueGrey100,
                Accent.Teal200,
                TextShade.WHITE
            );
        }
    }
}
