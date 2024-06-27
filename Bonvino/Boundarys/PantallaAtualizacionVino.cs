using Bonvino.Clases;
using Bonvino.Clases.Actualizacion;
using Bonvino.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonvino
{
    public partial class PantallaAtualizacionVino : Form
    {
        private GestorActualizacionVino gestor;
        private List<Bodega> bodegas;
        private Bodega bodegaElegida;
        public PantallaAtualizacionVino()
        {
            gestor = new GestorActualizacionVino();
            bodegaElegida = new Bodega();
            InitializeComponent();
        }

        private void PantallaAtualizacionVino_Load(object sender, EventArgs e)
        {

        }
        private void OpImportarActualizacionVino(object sender, EventArgs e)
        {     
            habilitarPantalla();
        }
        public void habilitarPantalla()
        {
            gestor.opImportarActualizacionVino(this);
        }
        public void mostrarBodegasActualizables(List<Bodega> bodegas)
        {
            btnActualizar.Enabled = true;
            dgvBodegas.Rows.Clear();
            this.bodegas = bodegas;
            foreach (var bodega in this.bodegas)
            {
                dgvBodegas.Rows.Add(bodega.nombre);
            }
            dgvBodegas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void seleccionBodega(object sender, EventArgs e)
        {
            bodegaElegida.nombre = dgvBodegas.CurrentCell.Value.ToString();
            gestor.seleccionBodega(bodegaElegida, this);
        }
        public void mostrarResumenVinosImportados(List<Vino> vinosResumen)
        {
            dgvResumenVinos.Rows.Clear();
            foreach (var vino in vinosResumen)
            {
                var fila = new string[] {
                    bodegaElegida.nombre,
                    vino.nombre,
                    vino.añada.ToString(),
                    vino.precioARS.ToString(),
                    vino.maridaje.nombre.ToString(),
                    vino.varietal.porcentajeComposicion.ToString(),
                    vino.varietal.tipoUva.nombre,
                    vino.notaDeCataBodega
                };
                dgvResumenVinos.Rows.Add(fila);
            }
            //Me ajusta dinamicamente el tamaño de las columnas
            dgvResumenVinos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
