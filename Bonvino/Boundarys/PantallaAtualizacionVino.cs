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
        //falta hacer un boton para asociar añ metodo seleccionBodega
        private void seleccionBodega(object sender, EventArgs e)
        {
            bodegaElegida.nombre = dgvBodegas.SelectedRows[0].Cells["Nombre"].Value.ToString();
            gestor.seleccionBodega(bodegaElegida);
        }
        public void mostrarResumenVinosImportados()
        {
            //completar
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvBodegas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
