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

namespace presentacion
{
    public partial class FrmDetalleArticulo : Form
    {
        //Variable para guardar el articulo en detalle
        private Articulo articulo;

        //Constructor que recibe el objeto
        public FrmDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Detalle del articulo";
        }

        private void FrmDetalleArticulo_Load(object sender, EventArgs e)
        {
            try
            {
             //Cargo los datos del producto en las cajas de texto
             txtCodigo.Text = articulo.Codigo;
             txtNombre.Text = articulo.Nombre;
             txtDescripcion.Text = articulo.Descripcion;
             txtPrecio.Text = articulo.Precio.ToString("0.00");

             cargarImagen(articulo.ImagenUrl);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
