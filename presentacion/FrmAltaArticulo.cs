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
using MaterialSkin;
using MaterialSkin.Controls;

namespace presentacion
{
    public partial class FrmAltaArticulo : MaterialForm
    {
        //Variable para guardar el articulo si es una modificacion
        private Articulo articulo = null;
       
        //Constructor para agregar producto
        public FrmAltaArticulo()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(
             Primary.Orange500,
             Primary.Orange700,
             Primary.Orange100,
             Accent.Yellow200,
             TextShade.WHITE
             );
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
            try
            {
                cargarDesplegables();
                configurarEstilo();

                if (articulo != null)
                {
                    cargarDatosArticulo();
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

        private void configurarEstilo()
        {
            if (articulo != null)
            {
                
                this.Text = "Modificar Artículo";
                MaterialSkinManager.Instance.ColorScheme = new ColorScheme(
                    Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE
                );
            }
            else
            {
               
                this.Text = "Nuevo Artículo";
                MaterialSkinManager.Instance.ColorScheme = new ColorScheme(
                    Primary.Orange500, Primary.Orange700, Primary.Orange100, Accent.Yellow200, TextShade.WHITE
                );
            }
        }

        private void cargarDesplegables()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            // ComboBox Marcas
            cboMarca.DataSource = marcaNegocio.listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";

            // ComboBox Categorias
            cboCategoria.DataSource = categoriaNegocio.listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";
        }

        private void cargarDatosArticulo()
        {
            // Mapeamos los datos del objeto a los controles
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();
            txtUrlImagen.Text = articulo.ImagenUrl;

            // Cargar la imagen visualmente
            cargarImagen(articulo.ImagenUrl);

            // Pre-seleccionar los desplegables
            cboMarca.SelectedValue = articulo.Marca.Id;
            cboCategoria.SelectedValue = articulo.Categoria.Id;
        }
    }
}