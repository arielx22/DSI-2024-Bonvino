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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarVinos
            // 
            this.btnImportarVinos.Location = new System.Drawing.Point(34, 45);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 212);
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
            this.dgvBodegas.Location = new System.Drawing.Point(6, 46);
            this.dgvBodegas.Name = "dgvBodegas";
            this.dgvBodegas.Size = new System.Drawing.Size(147, 150);
            this.dgvBodegas.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // PantallaAtualizacionVino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImportarVinos);
            this.Name = "PantallaAtualizacionVino";
            this.Text = "Actualización de Vinos";
            this.Load += new System.EventHandler(this.PantallaAtualizacionVino_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportarVinos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBodegas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}

