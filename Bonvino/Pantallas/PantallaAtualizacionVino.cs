using Bonvino.Clases;
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
            bodegas = gestor.opImportarActualizacionVino();
            mostrarBodegasActualizables();
        }
        public void mostrarBodegasActualizables()
        {
            dgvBodegas.Rows.Clear();

            foreach (var bodega in bodegas)
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
            bodegaElegida.nombre = dgvBodegas.SelectedRows[0].Cells["Nombre"].Value.ToString();
            var vinos = gestor.seleccionBodega(bodegaElegida);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
