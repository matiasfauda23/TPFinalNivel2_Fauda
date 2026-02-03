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
        //Variable para guardar el articulo si es una modificacion
        private Articulo articulo = null;
       
        //Constructor para agregar producto
        public FrmAltaArticulo()
        {
            InitializeComponent();
        }
        //Constructor para modificar producto
        public FrmAltaArticulo(Articulo articuloSeleccionado)
        {
            InitializeComponent();
            this.articulo = articuloSeleccionado;
            Text = "Modificar Artículo";

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

                //Si el articulo es distinto de null, es una modificacion
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtUrlImagen.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);
                    //Seleccionar la marca y categoria correspondiente en los combobox
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (validarAlta())
            {
                return;
            }
            
            try
            {

                //Si la variable esta vacia, entonces es un alta
                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                
                //Cargo el objeto articulo con los datos del formulario
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                //Si el id es distinto de 0, es una modificacion
                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Articulo modificado exitosamente");
                }
                else
                {
                    //Sino, es un alta
                    negocio.agregar(articulo);
                    MessageBox.Show("Articulo agregado exitosamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
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

        private bool validarAlta()
        {
            //Validar campos vacios
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, completa los campos obligatorios (Codigo y Nombre).");
                return true;
            }

            //Validar que sea numerico
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser numérico.");
                return true;
            }

            //Validar que no sea negativo
            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.");
                return true;
            }

            // Si paso todo, entonces esta bien
            return false;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}