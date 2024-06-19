namespace Bonvino
{
    partial class PantallaAtualizacionVino
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImportarVinos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBodegas = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TipoUva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Varietal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maridaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioARS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Añada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResumenVinos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenVinos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarVinos
            // 
            this.btnImportarVinos.Location = new System.Drawing.Point(12, 24);
            this.btnImportarVinos.Name = "btnImportarVinos";
            this.btnImportarVinos.Size = new System.Drawing.Size(109, 23);
            this.btnImportarVinos.TabIndex = 0;
            this.btnImportarVinos.Text = "Importar Vinos";
            this.btnImportarVinos.UseVisualStyleBackColor = true;
            this.btnImportarVinos.Click += new System.EventHandler(this.OpImportarActualizacionVino);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBodegas);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bodegas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvBodegas
            // 
            this.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBodegas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre});
            this.dgvBodegas.Location = new System.Drawing.Point(6, 19);
            this.dgvBodegas.Name = "dgvBodegas";
            this.dgvBodegas.Size = new System.Drawing.Size(148, 158);
            this.dgvBodegas.TabIndex = 0;
            this.dgvBodegas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBodegas_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(18, 261);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.seleccionBodega);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvResumenVinos);
            this.groupBox2.Location = new System.Drawing.Point(179, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 193);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumen";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // TipoUva
            // 
            this.TipoUva.HeaderText = "TipoUva";
            this.TipoUva.Name = "TipoUva";
            // 
            // Varietal
            // 
            this.Varietal.HeaderText = "Varietal";
            this.Varietal.Name = "Varietal";
            // 
            // Maridaje
            // 
            this.Maridaje.HeaderText = "Maridaje";
            this.Maridaje.Name = "Maridaje";
            // 
            // PrecioARS
            // 
            this.PrecioARS.HeaderText = "PrecioARS";
            this.PrecioARS.Name = "PrecioARS";
            // 
            // Añada
            // 
            this.Añada.HeaderText = "Añada";
            this.Añada.Name = "Añada";
            // 
            // Vino
            // 
            this.Vino.HeaderText = "Vino";
            this.Vino.Name = "Vino";
            // 
            // Bodega
            // 
            this.Bodega.HeaderText = "Bodega";
            this.Bodega.Name = "Bodega";
            // 
            // dgvResumenVinos
            // 
            this.dgvResumenVinos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumenVinos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bodega,
            this.Vino,
            this.Añada,
            this.PrecioARS,
            this.Maridaje,
            this.Varietal,
            this.TipoUva});
            this.dgvResumenVinos.Location = new System.Drawing.Point(6, 19);
            this.dgvResumenVinos.Name = "dgvResumenVinos";
            this.dgvResumenVinos.Size = new System.Drawing.Size(746, 158);
            this.dgvResumenVinos.TabIndex = 0;
            this.dgvResumenVinos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PantallaAtualizacionVino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 292);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImportarVinos);
            this.Name = "PantallaAtualizacionVino";
            this.Text = "Actualización de Vinos";
            this.Load += new System.EventHandler(this.PantallaAtualizacionVino_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenVinos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportarVinos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBodegas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvResumenVinos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Añada;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioARS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maridaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Varietal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoUva;
    }
}

