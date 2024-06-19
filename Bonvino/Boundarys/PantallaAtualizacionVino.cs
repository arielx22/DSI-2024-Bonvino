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
            gestor = new GestorActualizacionVino(this);
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
            gestor.opImportarActualizacionVino();
        }
        public void mostrarBodegasActualizables(List<Bodega> bodegas)
        {
            dgvBodegas.Rows.Clear();
            this.bodegas = bodegas;
            foreach (var bodega in this.bodegas)
            {
                /*
                var fila = new string[] {
                    bodega.nombre.ToString()
                };
                dgvBodegas.Rows.Add(fila);*/
                dgvBodegas.Rows.Add(bodega.nombre);
            }

        }
        private void seleccionBodega(object sender, EventArgs e)
        {
            bodegaElegida.nombre = dgvBodegas.CurrentCell.Value.ToString();
            gestor.seleccionBodega(bodegaElegida);
        }
        public void mostrarResumenVinosImportados(List<VinoActualizacion> vinosResumen)
        {
            //completar
            dgvResumenVinos.Rows.Clear();
            foreach (var vino in vinosResumen)
            {
                var fila = new string[] {
                    bodegaElegida.nombre,
                    vino.nombre,
                    vino.añada.ToString(),
                    vino.precioARS.ToString(),
                    vino.maridaje.ToString(),
                    vino.varietal.porcentajeComposicion.ToString(),
                    vino.varietal.tipoUva.nombre
                };
                dgvResumenVinos.Rows.Add(fila);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvBodegas_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
