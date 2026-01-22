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
    public partial class FrmAltaArticulo : Form
    {
        public FrmAltaArticulo()
        {
            InitializeComponent();
        }

        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                //Llenamos el comboBox de Marcas
                cboMarca.DataSource = marcaNegocio.listar();
                //ValueMember es el valor interno
                cboMarca.ValueMember = "Id";
                //DisplayMember es lo que se muestra
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
         if(validarAlta())
            {
                return;
            }
            //Creo el objeto articulo y negocio
            Articulo nuevoArticulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                //Cargo el objeto nuevoArticulo con los datos del formulario
                nuevoArticulo.Codigo = txtCodigo.Text;
                nuevoArticulo.Nombre = txtNombre.Text;
                nuevoArticulo.Descripcion = txtDescripcion.Text;
                nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);
                nuevoArticulo.Marca = (Marca)cboMarca.SelectedItem;
                nuevoArticulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                //Llamo al metodo agregar de negocio
                negocio.agregar(nuevoArticulo);
                MessageBox.Show("Articulo agregado exitosamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarAlta()
        {
            //Valido campos vacios
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, completa los campos obligatorios (Código y Nombre).");
                //Devuelvo true si hay un error
                return true; 
            }
            //Valido numeros
            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("El precio debe ser numérico.");
                return true;
            }
            //Si paso todo, entonces esta bien
            return false;
        }
            
            



    }
}