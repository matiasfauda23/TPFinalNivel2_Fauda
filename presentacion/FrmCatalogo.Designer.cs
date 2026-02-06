using System;

namespace presentacion
{
    partial class FrmCatalogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblCampo = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(370, 23);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(320, 22);
            this.txtFiltro.TabIndex = 0;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(256, 29);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(91, 20);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "FiltroRapido";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(50, 133);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.RowTemplate.Height = 24;
            this.dgvArticulos.Size = new System.Drawing.Size(851, 308);
            this.dgvArticulos.TabIndex = 2;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgregar.Location = new System.Drawing.Point(921, 66);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(99, 42);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModificar.Location = new System.Drawing.Point(1044, 65);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(99, 44);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.Location = new System.Drawing.Point(1167, 65);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 44);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCampo.Location = new System.Drawing.Point(26, 49);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(60, 20);
            this.lblCampo.TabIndex = 7;
            this.lblCampo.Text = "Campo:";
            // 
            // cboCampo
            // 
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(96, 46);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 24);
            this.cboCampo.TabIndex = 8;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCriterio.Location = new System.Drawing.Point(248, 49);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(61, 20);
            this.lblCriterio.TabIndex = 9;
            this.lblCriterio.Text = "Criterio:";
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(324, 46);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 24);
            this.cboCriterio.TabIndex = 10;
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(480, 50);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(116, 20);
            this.lblFiltroAvanzado.TabIndex = 11;
            this.lblFiltroAvanzado.Text = "Filtro Avanzado:";
            // 
            // btnFiltro
            // 
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltro.Location = new System.Drawing.Point(756, 41);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(96, 39);
            this.btnFiltro.TabIndex = 13;
            this.btnFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxArticulo.Location = new System.Drawing.Point(932, 133);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(302, 308);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 14;
            this.pbxArticulo.TabStop = false;
            // 
            // btnDetalle
            // 
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(50, 76);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(120, 33);
            this.btnDetalle.TabIndex = 15;
            this.btnDetalle.Text = "Ver Detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(610, 50);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(121, 22);
            this.txtFiltroAvanzado.TabIndex = 16;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.Location = new System.Drawing.Point(872, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 39);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.Controls.Add(this.btnLimpiar);
            this.gbxFiltros.Controls.Add(this.lblCampo);
            this.gbxFiltros.Controls.Add(this.txtFiltroAvanzado);
            this.gbxFiltros.Controls.Add(this.cboCampo);
            this.gbxFiltros.Controls.Add(this.lblCriterio);
            this.gbxFiltros.Controls.Add(this.cboCriterio);
            this.gbxFiltros.Controls.Add(this.btnFiltro);
            this.gbxFiltros.Controls.Add(this.lblFiltroAvanzado);
            this.gbxFiltros.Location = new System.Drawing.Point(82, 477);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(1010, 117);
            this.gbxFiltros.TabIndex = 18;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Text = "Busqueda avanzada";
            // 
            // FrmCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 747);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.txtFiltro);
            this.Name = "FrmCatalogo";
            this.Text = "FrmCatalogo";
            this.Load += new System.EventHandler(this.FrmCatalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox gbxFiltros;
    }
}

